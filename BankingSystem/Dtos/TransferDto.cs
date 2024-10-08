namespace BankingSystem.Dtos
{
    public class TransferDto
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }

}
