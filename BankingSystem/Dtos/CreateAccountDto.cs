using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        public string AccountType { get; set; }
        [Required]
        public string AccountName { get; set; }
    }


}
