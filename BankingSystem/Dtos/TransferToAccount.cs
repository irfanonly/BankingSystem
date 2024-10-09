using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class TransferToAccount
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Range(0.01, (double)decimal.MaxValue)]
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"Id:{Id},Amount:{Amount}";
        }
    }

}
