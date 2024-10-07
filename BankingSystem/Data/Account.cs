using BankingSystem.Enum;

namespace BankingSystem.Data
{
    
    public class Account
    {
        public Guid AccountId { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        //public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public bool IsClosed { get; set; }
    }
}
