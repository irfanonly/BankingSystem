﻿using AutoMapper;
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
        private readonly IBankAccDBContext _db;
        private readonly IMapper _mapper;
        public AccountService(IBankAccDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }




        public async Task<Guid> CreateAsync(CreateAccountDto account)
        {
            var accountType = await _db.AccountTypes.FindAsync(account.AccountTypeId);
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
            _db.Accounts.Add(newAccount);
            await _db.SaveChangesAsync();
            return newAccount.Id;
        }

        public async Task<AccountDto?> GetDtoAsync(Guid id)
        {
            var account =  await _db.Accounts.Include(x => x.Transactions).Include(x => x.AccountType).FirstOrDefaultAsync(x => x.Id == id);

            if (account == null) {
                throw new NotFoundException($"The account is not found, Id: {id}");
            }


            return new AccountDto
            {
                Name = account.Name,
                AccountTypeName = account.AccountType.Name,
                Balance = account.Balance,
                Id = account.Id,
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
            return await _db.Accounts.FindAsync( id);
        }

        public async Task CloseAsync(Guid Id)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                var account = _db.Accounts.FirstOrDefault(x => x.Id == Id);

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

                    await _db.ClosedAccounts.AddAsync(closed);

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
