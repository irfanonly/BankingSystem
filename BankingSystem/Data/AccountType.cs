namespace BankingSystem.Data
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        public const string Checking = "Checking";
        public const string Savings = "Savings";
    }
}
