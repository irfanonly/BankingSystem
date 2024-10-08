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

        public DbSet<User> Users { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ClosedAccount> ClosedAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Transfer> Transfers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { Id = 1, Name = "Savings" },
                new AccountType { Id = 2, Name = "Checking" }
            );
        }
        
    }

    
}
