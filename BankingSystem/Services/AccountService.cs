using AutoMapper;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Exceptions;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<Account> _db;
        private readonly IGenericRepository<AccountType> _dbType;
        private readonly IGenericRepository<ClosedAccount> _dbClosed;
        private readonly IMapper _mapper;
        public AccountService(IGenericRepository<Account> db, IMapper mapper,
            IGenericRepository<AccountType> dbType, IGenericRepository<ClosedAccount> dbClosed)
        {
            _db = db;
            _mapper = mapper;
            _dbType = dbType;
            _dbClosed = dbClosed;
        }




        public async Task<Guid> CreateAsync(CreateAccountDto account)
        {
            var accountType = await _dbType.FindAsync(account.AccountTypeId);
            if (accountType == null)
            {
                throw new NotFoundException($"The account type is not exists, AccountTypeId: {account.AccountTypeId}");
            }

            if (accountType.Name == AccountType.Checking)
            {
                if (account.OverDraftLimit == null)
                {
                    throw new BadRequestException("The overdraft limit is required");
                }
            }
            // assumption: OverDraftLimit is applicable only for Checking account
            else if (account.OverDraftLimit != null)
            {
                throw new BadRequestException($"The overdraft limit is not applicable for {accountType.Name}");

            }

            var newAccount = _mapper.Map<Account>(account);
            await _db.AddAsync(newAccount);
            await _db.SaveChangesAsync();
            return newAccount.Id;
        }

        public async Task<AccountDto?> GetDtoAsync(Guid id)
        {
            var accounts =  await _db.GetWithIncludeAsync(x => x.Transactions, x => x.AccountType);

            var account = accounts?.FirstOrDefault();

            if (account == null) {
                throw new NotFoundException($"The account is not found, Id: {id}");
            }


            return new AccountDto
            {
                Name = account.Name,
                AccountTypeName = account.AccountType.Name,
                Balance = account.Balance,
                Id = account.Id,
                IsClosed = account.IsClosed,
                Transactions = account.Transactions?.TakeLast(10)?.Select(x => new TransactionDto
                {
                    Amount = x.Amount,
                    TrnMethod = x.TrnMethod,
                    TrnType = x.TrnType,
                }).ToList()
            };


        }

        public async Task<Account?> GetAsync(Guid id)
        {
            return await _db.FindAsync( id);
        }

        public async Task CloseAsync(Guid Id)
        {
            using (var transaction = await _db.BeginTransactionAsync())
            {
                var account = await _db.GetByIdAsync(Id);

                if (account == null) {
                    throw new NotFoundException("The account is not found");
                }

                try
                {
                    account.IsClosed = true;

                    var closed = new ClosedAccount
                    {
                        AccountId = account.Id,
                        ClosedOn = DateTime.UtcNow,
                    };

                    await _dbClosed.AddAsync(closed);

                    await _db.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }


            }

        }
    }
}
