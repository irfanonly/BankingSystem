using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Data
{
    
    public class Account
    {
        public Guid AccountId { get; set; } = Guid.NewGuid();
        [AllowedValues("Savings", "Checking")]
        public string AccountType { get; set; }
        // Full name of the user
        public string AccountName { get; set; }
        //Account number also can added.. it will be some format with sequence of number
        public decimal Balance { get; set; }
        //public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public bool IsClosed { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
