using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data
{
    public class Transfer
    {
        public int Id { get; set; }
        public string? Remarks { get; set; }

        public DateTime TransferredOn { get; set; } = DateTime.UtcNow;
        public ICollection<TransferTransaction> TransferTransactions { get; set; } = new List<TransferTransaction>();
    }
}
