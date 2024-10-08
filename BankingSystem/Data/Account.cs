using BankingSystem.Constants;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [AllowedValues(UserRole.Admin, UserRole.Customer)]
        public string Role { get; set; } // Admin or Customer
    }

    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }

    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public AccountType AccountType { get; set; }
        public bool IsClosed { get; set; }
        public User User { get; set; }
    }

    public class ClosedAccount
    {
        public int Id { get; set; }
        public Guid AccID { get; set; }
        public DateTime ClosedOn { get; set; }
        public User? ClosedBy { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public Guid AccID { get; set; }
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



    public class Transfer
    {
        public int Id { get; set; }
        public int FromTransferId { get; set; }
        public int ToTransferId { get; set; }
        public string Remarks { get; set; }
    }
}
