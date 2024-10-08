using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Dtos
{
    public class UpdateAccountTypeDto
    {

        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
    }

    //public class GetAccountTypeDto
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public bool IsDeleted { get; set; }
    //    public DateTime CreatedOn { get; set; } 
    //    public DateTime UpdatedOn { get; set; }
    //}


}
