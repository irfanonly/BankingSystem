using BankingSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data
{
    public class BankAccDBContext : IBankAccDBContext
    {
        public BankAccDBContext(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
