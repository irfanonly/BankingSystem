using BankingSystem.Constants;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
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
                    var account = await _db.Accounts.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == depositWithdrawalDto.AccountId);

                    account!.Balance += depositWithdrawalDto.Amount;

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

        public Task TransferAsync(TransferDto transferDto)
        {
            throw new NotImplementedException();
        }

        public async Task WithdrawalAsync(DepositWithdrawalDto depositWithdrawalDto)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var account = await _db.Accounts.Include(x => x.Transactions)
                        .Include(x => x.AccountType)
                        .FirstOrDefaultAsync(x => x.Id == depositWithdrawalDto.AccountId);

                    if (account.AccountType.Name == AccountType.Checking 
                        && account.Balance + account.OverDraftLimit < depositWithdrawalDto.Amount)
                    {
                        throw new Exception("The OverDraftLimit is exceeded.");
                    }
                    else if(account.AccountType.Name != AccountType.Checking 
                        && account.Balance < depositWithdrawalDto.Amount)
                    {
                        throw new Exception("The withdrawal amount cannot be greater than your balance on your account");

                    }

                    account!.Balance -= depositWithdrawalDto.Amount;

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
