using BankingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Interface
{
    public abstract class IBankAccDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public IBankAccDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Account> Accounts { get; set; }
    }

    
}
