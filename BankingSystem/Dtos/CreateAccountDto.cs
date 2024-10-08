using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        public int AccountTypeId { get; set; }
        [Required]
        public string AccountName { get; set; }
    }


}
