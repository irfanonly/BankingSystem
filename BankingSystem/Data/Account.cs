namespace BankingSystem.Data
{

    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
        public decimal? OverDraftLimit { get; set; }
        public bool IsClosed { get; set; }
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
