using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class UpdateAccountTypeDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Name:{Name}, Id:{Id}";
        }
    }


}
