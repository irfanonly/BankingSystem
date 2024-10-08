using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class CreateAccountTypeDto
    {
        
        [Required]
        public string Name { get; set; }
    }



}
