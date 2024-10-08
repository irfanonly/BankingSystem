using BankingSystem.Constants;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [AllowedValues(UserRole.Admin, UserRole.Customer)]
        public string Role { get; set; } // Admin or Customer
    }
}
