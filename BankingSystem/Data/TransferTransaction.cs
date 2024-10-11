namespace BankingSystem.Data
{
    public class TransferTransaction
    {
        public int TransferId { get; set; }
        public virtual Transfer Transfer { get; set; }
        public long TransactionId { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
