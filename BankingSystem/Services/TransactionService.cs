using BankingSystem.Constants;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Exceptions;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _db;
        private readonly IGenericRepository<Transfer> _dbTrans;
        private readonly IGenericRepository<Account> _dbAccount;
        public TransactionService(IGenericRepository<Transaction> db,
            IGenericRepository<Transfer> dbTrans,
            IGenericRepository<Account> dbAccount)
        {
            _db = db;
            _dbTrans = dbTrans;
            _dbAccount = dbAccount;
        }

        private void ValidateAccount(Account? account, Guid id)
        {
            if (account == null)
            {
                throw new NotFoundException($"The account is not found for the transaction, account id: {id}");
            }

            if (account.IsClosed)
            {
                throw new BadRequestException($"The account status is closed");
            }
        }

        public async Task DepositAsync(DepositWithdrawalDto depositWithdrawalDto)
        {
            using (var transaction = await _db.BeginTransactionAsync())
            {
                try
                {
                    var account = await GetAccount(depositWithdrawalDto.AccountId);

                    ValidateAccount(account, depositWithdrawalDto.AccountId);

                    AddCredit(account!, depositWithdrawalDto.Amount);

                    account!.Transactions.Add(new Transaction
                    {
                        Amount = depositWithdrawalDto.Amount,
                        TrnMethod = TransactionMethod.Deposit,
                        TrnType = TransactionType.Credit,
                        TrnOn = DateTime.UtcNow

                    });

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        private void AmountLimitCheck(Account account, decimal amount)
        {
            if (account.AccountType.Name == AccountType.Checking
                        && account.Balance + account.OverDraftLimit < amount)
            {
                throw new BadRequestException("The OverDraftLimit is exceeded.");
            }
            else if (account.AccountType.Name != AccountType.Checking
                        && account.Balance < amount)
            {
                throw new BadRequestException("The withdrawal amount cannot be greater than your balance on your account");

            }
        }

        private void AddCredit(Account account, decimal amount)
        {
            account!.Balance += amount;
        }

        private void AddDebit(Account account , decimal amount)
        {
            account!.Balance -= amount;

            
        }

        public async Task TransferAsync(TransferDto transferDto)
        {
            using (var transaction = await _db.BeginTransactionAsync())
            {
                try
                {

                    var fromAccount = await GetAccount(transferDto.FromAccountId);

                    ValidateAccount(fromAccount, transferDto.FromAccountId);

                    var total = transferDto.ToAccounts.Sum(x => x.Amount);

                    AmountLimitCheck(fromAccount!, total);

                    AddDebit(fromAccount!, total);

                    var trn = new Transaction
                    {
                        Amount = total,
                        TrnMethod = TransactionMethod.Transfer,
                        TrnType = TransactionType.Debit,
                        TrnOn = DateTime.UtcNow

                    };

                    fromAccount!.Transactions.Add(trn);

                    var transfer = new Transfer { Remarks = transferDto.Remarks };
                    
                    List<Transaction> transactions = new List<Transaction>();   
                    foreach (var transferTo in transferDto.ToAccounts)
                    {
                        var toAccount = await GetAccount(transferTo.Id);

                        ValidateAccount(toAccount, transferTo.Id);

                        AddCredit(toAccount!, transferTo.Amount );

                        var toTrn = new Transaction
                        {
                            Amount = transferTo.Amount,
                            TrnMethod = TransactionMethod.Transfer,
                            TrnType = TransactionType.Credit,
                            TrnOn = DateTime.UtcNow

                        };

                        toAccount!.Transactions.Add(toTrn);


                        transactions.Add( toTrn );
                    }

                    await _db.SaveChangesAsync();



                    // Add transfer seperately to identify
                    

                    transfer.TransferTransactions.Add(new TransferTransaction { TransactionId = trn.Id });
                    transactions.ForEach(x =>
                    {
                        transfer.TransferTransactions.Add(new TransferTransaction { TransactionId = x.Id });
                    });

                    await _dbTrans.AddAsync(transfer);
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        private async Task<Account?> GetAccount(Guid Id)
        {
            var accounts = await _dbAccount.GetWithIncludeAsync(x => x.Transactions, x => x.AccountType);


            return accounts.FirstOrDefault(x => x.Id == Id);
        }
        public async Task WithdrawalAsync(DepositWithdrawalDto depositWithdrawalDto)
        {
            using (var transaction = await _db.BeginTransactionAsync())
            {
                try
                {
                    var account = await GetAccount(depositWithdrawalDto.AccountId);

                    ValidateAccount(account, depositWithdrawalDto.AccountId);

                    AmountLimitCheck(account!, depositWithdrawalDto.Amount);

                    AddDebit(account!, depositWithdrawalDto.Amount);

                    account!.Transactions.Add(new Transaction
                    {
                        Amount = depositWithdrawalDto.Amount,
                        TrnMethod = TransactionMethod.Withdrawal,
                        TrnType = TransactionType.Debit,
                        TrnOn = DateTime.UtcNow

                    });

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
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
