using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class DepositWithdrawalDto
    {
        [Required]
        public Guid AccountId { get; set; }
        [Range(0.0, (double)decimal.MaxValue)]
        [Required]
        public decimal Amount { get; set; }
    }

}
