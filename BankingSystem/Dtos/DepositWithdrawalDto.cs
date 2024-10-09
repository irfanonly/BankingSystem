using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class DepositWithdrawalDto
    {
        [Required]
        public Guid AccountId { get; set; }
        [Range(0.01, (double)decimal.MaxValue)]
        [Required]
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"AccountId:{AccountId},Amount:{Amount}";
        }
    }

}
