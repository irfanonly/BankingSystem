using BankingSystem.Constants;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IBankAccDBContext _db;
        public TransactionService(IBankAccDBContext db)
        {
            _db = db;
        }

        public async Task DepositAsync(DepositWithdrawalDto depositWithdrawalDto)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var account = await GetAccount(depositWithdrawalDto.AccountId);

                    AddCredit(account, depositWithdrawalDto.Amount);

                    account.Transactions.Add(new Transaction
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
                throw new Exception("The OverDraftLimit is exceeded.");
            }
            else if (account.AccountType.Name != AccountType.Checking
                        && account.Balance < amount)
            {
                throw new Exception("The withdrawal amount cannot be greater than your balance on your account");

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
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {

                    var fromAccount = await GetAccount(transferDto.FromAccountId);

                    var total = transferDto.ToAccounts.Sum(x => x.Amount);

                    AmountLimitCheck(fromAccount, total);

                    AddDebit(fromAccount, total);

                    var trn = new Transaction
                    {
                        Amount = total,
                        TrnMethod = TransactionMethod.Transfer,
                        TrnType = TransactionType.Debit,
                        TrnOn = DateTime.UtcNow

                    };

                    fromAccount.Transactions.Add(trn);

                    var transfer = new Transfer { Remarks = transferDto.Remarks };
                    

                    

                    List<Transaction> transactions = new List<Transaction>();   
                    foreach (var transferTo in transferDto.ToAccounts)
                    {
                        var toAccount = await GetAccount(transferTo.Id);
                        if (toAccount == null)
                        {
                            throw new Exception($"The Account not found, account id:{transferTo.Id}");
                        }
                        AddCredit(toAccount, transferTo.Amount );

                        var toTrn = new Transaction
                        {
                            Amount = transferTo.Amount,
                            TrnMethod = TransactionMethod.Transfer,
                            TrnType = TransactionType.Credit,
                            TrnOn = DateTime.UtcNow

                        };
                        toAccount.Transactions.Add(toTrn);


                        transactions.Add( toTrn );
                    }

                    await _db.SaveChangesAsync();



                    // Add transfer seperately to identify
                    

                    transfer.TransferTransactions.Add(new TransferTransaction { TransactionId = trn.Id });
                    transactions.ForEach(x =>
                    {
                        transfer.TransferTransactions.Add(new TransferTransaction { TransactionId = x.Id });
                    });

                    await _db.Transfers.AddAsync(transfer);
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
            return await _db.Accounts.Include(x => x.Transactions)
                        .Include(x => x.AccountType)
                        .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task WithdrawalAsync(DepositWithdrawalDto depositWithdrawalDto)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var account = await GetAccount(depositWithdrawalDto.AccountId);

                    AmountLimitCheck(account, depositWithdrawalDto.Amount);

                    AddDebit(account, depositWithdrawalDto.Amount);

                    account.Transactions.Add(new Transaction
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
