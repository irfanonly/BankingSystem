using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class TransferDto
    {
        [Required]
        public Guid FromAccountId { get; set; }
        [Required]
        public IList<TransferToAccount> ToAccounts { get; set; }

        public string? Remarks { get; set; }

    }

}
