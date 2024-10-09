using BankingSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class CreateAccountTypeDto
    {
        
        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }



}
