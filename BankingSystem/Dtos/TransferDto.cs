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

        public override string ToString()
        {
            return $"FromAccountId:{FromAccountId},Remarks:{Remarks},ToAccounts:{string.Join(",", ToAccounts?.Select(x => x.ToString()))}";
        }
    }

}
