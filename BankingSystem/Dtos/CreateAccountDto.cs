using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        [AllowedValues("Savings", "Checking", ErrorMessage = "AccountType should be either Savings or Checking")]
        public string AccountType { get; set; }
        [Required]
        public string AccountName { get; set; }
    }


}
