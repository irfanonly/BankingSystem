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
        //public DbSet<Transfer> Transfers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { Id = 1, Name = "Savings" },
                new AccountType { Id = 2, Name = "Checking" }
            );


            // seeding some dummy data

            var account1Id = Guid.NewGuid();
            var account2Id = Guid.NewGuid();
            var account3Id = Guid.NewGuid();

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = account1Id,
                    Name = "Primary Savings Account",
                    Balance = 5000.00m,
                    AccountTypeId = 1,
                    IsClosed = false
                },
                new Account
                {
                    Id = account2Id,
                    Name = "Business Checking Account",
                    Balance = 15000.00m,
                    AccountTypeId = 2,
                    IsClosed = false
                    
                },
                new Account
                {
                    Id = account3Id,
                    Name = "Fixed Deposit Account",
                    Balance = 25000.00m,
                    AccountTypeId = 1,
                    IsClosed = false
                    
                }
            );

            //Seed data for Transactions

           modelBuilder.Entity<Transaction>().HasData(
               new Transaction
               {
                   Id = 1,
                   AccountId = account1Id,
                   Amount = 500.00m,
                   TrnType = "Credit",
                   TrnMethod = "Deposit",
                   TrnOn = DateTime.Now
               },
               new Transaction
               {
                   Id = 2,
                   AccountId = account1Id,
                   Amount = 100.00m,
                   TrnType = "Debit",
                   TrnMethod = "Withdrawal",
                   TrnOn = DateTime.Now.AddDays(-2)
               },
               new Transaction
               {
                   Id = 3,
                   AccountId = account2Id,
                   Amount = 2000.00m,
                   TrnType = "Credit",
                   TrnMethod = "Deposit",
                   TrnOn = DateTime.Now.AddDays(-5)
               },
               new Transaction
               {
                   Id = 4,
                   AccountId = account3Id,
                   Amount = 5000.00m,
                   TrnType = "Credit",
                   TrnMethod = "Deposit",
                   TrnOn = DateTime.Now.AddMonths(-1)
               },
               new Transaction
               {
                   Id = 5,
                   AccountId = account3Id,
                   Amount = 3000.00m,
                   TrnType = "Credit",
                   TrnMethod = "Deposit",
                   TrnOn = DateTime.Now.AddMonths(-2)
               }
           );
        }
        
    }

    
}
