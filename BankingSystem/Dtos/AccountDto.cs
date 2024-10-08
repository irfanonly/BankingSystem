namespace BankingSystem.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionDto>? Transactions { get; set; }
        public string AccountTypeName { get; set; }
    }

}
