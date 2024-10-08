namespace BankingSystem.Data
{
    public class ClosedAccount
    {
        public int Id { get; set; }
        public Guid AccID { get; set; }
        public DateTime ClosedOn { get; set; }
        public User? ClosedBy { get; set; }
    }
}
