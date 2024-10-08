using BankingSystem.Constants;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Data
{
    public class Transaction
    {
        public long Id { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }

        // Better we can handle this from table
        [AllowedValues(TransactionType.Credit, TransactionType.Debit)]
        public string TrnType { get; set; } 
        // Better we can handle this from table
        [AllowedValues(TransactionMethod.Transfer, TransactionMethod.Withdrawal, TransactionMethod.Deposit)]
        public string TrnMethod { get; set; } 
        public User? TrnBy { get; set; }
        public DateTime TrnOn { get; set; }
    }
}
