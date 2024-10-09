using BankingSystem.Constants;
using BankingSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        public int AccountTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.01, (double)decimal.MaxValue)]
        public decimal? OverDraftLimit { get; set; }
    }


}
