using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class TransferToAccount
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }

}
