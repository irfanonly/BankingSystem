using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Exceptions;
using BankingSystem.Interface;
using BankingSystem.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<IGenericRepository<Transaction>> _mockTransactionRepository;
        private readonly Mock<IGenericRepository<Transfer>> _mockTransferRepository;
        private readonly Mock<IGenericRepository<Account>> _mockAccountRepository;
        private readonly Mock<IDbContextTransaction> _mockTransaction; 
        private readonly TransactionService _transactionService;

        public TransactionServiceTests()
        {
            _mockTransactionRepository = new Mock<IGenericRepository<Transaction>>();
            _mockTransferRepository = new Mock<IGenericRepository<Transfer>>();
            _mockAccountRepository = new Mock<IGenericRepository<Account>>();
            _mockTransaction = new Mock<IDbContextTransaction>(); 

            _transactionService = new TransactionService(
                _mockTransactionRepository.Object,
                _mockTransferRepository.Object,
                _mockAccountRepository.Object);
        }

        [Fact]
        public async Task DepositAsync_ShouldAddCreditToAccount_WhenAccountExists()
        {
            // Arrange
            var account = new Account { Id = Guid.NewGuid(), Balance = 100, IsClosed = false, Transactions = new List<Transaction>() };
            var depositDto = new DepositWithdrawalDto { AccountId = account.Id, Amount = 50 };

            _mockAccountRepository.Setup(repo => repo.GetWithIncludeAsync(It.IsAny<Expression<Func<Account, object>>[]>()))
                .ReturnsAsync(new List<Account> { account });
            _mockTransactionRepository.Setup(repo => repo.BeginTransactionAsync())
                .ReturnsAsync(_mockTransaction.Object);
            _mockTransactionRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            await _transactionService.DepositAsync(depositDto);

            // Assert
            Assert.Equal(150, account.Balance);
            Assert.Single(account.Transactions);
            _mockTransaction.Verify(t => t.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task WithdrawalAsync_ShouldDebitAccount_WhenSufficientBalance()
        {
            // Arrange
            var account = new Account { Id = Guid.NewGuid(), Balance = 200, IsClosed = false,
                Transactions = new List<Transaction>(),
                AccountType = new AccountType { Name = "Savings" },
            };
            var withdrawalDto = new DepositWithdrawalDto { AccountId = account.Id, Amount = 100 };

            _mockAccountRepository.Setup(repo => repo.GetWithIncludeAsync(It.IsAny<Expression<Func<Account, object>>[]>()))
                .ReturnsAsync(new List<Account> { account });
            _mockTransactionRepository.Setup(repo => repo.BeginTransactionAsync())
                .ReturnsAsync(_mockTransaction.Object);
            _mockTransactionRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            await _transactionService.WithdrawalAsync(withdrawalDto);

            // Assert
            Assert.Equal(100, account.Balance);
            Assert.Single(account.Transactions);
            _mockTransaction.Verify(t => t.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task TransferAsync_ShouldTransferFunds_WhenAccountsAreValid()
        {
            // Arrange
            var fromAccount = new Account { Id = Guid.NewGuid(), Balance = 500, IsClosed = false, 
                Transactions = new List<Transaction>() ,
                AccountType = new AccountType { Name = "Savings" },
            };
            var toAccount = new Account { Id = Guid.NewGuid(), Balance = 100, IsClosed = false,
                Transactions = new List<Transaction>(),
                AccountType = new AccountType { Name = "Savings" },
            };
            var transferDto = new TransferDto
            {
                FromAccountId = fromAccount.Id,
                ToAccounts = new List<TransferToAccount> { new TransferToAccount { Id = toAccount.Id, Amount = 200 } },
                Remarks = "Test transfer"
            };

            _mockAccountRepository.Setup(repo => repo.GetWithIncludeAsync(It.IsAny<Expression<Func<Account, object>>[]>()))
                .ReturnsAsync(new List<Account> { fromAccount, toAccount });
            _mockTransactionRepository.Setup(repo => repo.BeginTransactionAsync())
                .ReturnsAsync(_mockTransaction.Object);
            _mockTransactionRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            await _transactionService.TransferAsync(transferDto);

            // Assert
            Assert.Equal(300, fromAccount.Balance);
            Assert.Equal(300, toAccount.Balance);
            Assert.Single(fromAccount.Transactions);
            Assert.Single(toAccount.Transactions);
            _mockTransaction.Verify(t => t.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task TransferAsync_ShouldRollbackTransaction_WhenExceptionOccurs()
        {
            // Arrange
            var fromAccount = new Account { Id = Guid.NewGuid(), Balance = 500, IsClosed = false,
                AccountType= new AccountType { Name = "Savings"},
                Transactions = new List<Transaction>()
            };
            var toAccount = new Account { Id = Guid.NewGuid(), Balance = 100, IsClosed = false,
                AccountType = new AccountType { Name = "Savings" } ,
                Transactions = new List<Transaction>()
            };
            var transferDto = new TransferDto
            {
                FromAccountId = fromAccount.Id,
                ToAccounts = new List<TransferToAccount> { new TransferToAccount { Id = toAccount.Id, Amount = 300 } }
            };

            _mockAccountRepository.Setup(repo => repo.GetWithIncludeAsync(It.IsAny<Expression<Func<Account, object>>[]>()))
                .ReturnsAsync(new List<Account> { fromAccount, toAccount });
            _mockTransactionRepository.Setup(repo => repo.BeginTransactionAsync())
                .ReturnsAsync(_mockTransaction.Object);
            _mockTransactionRepository.Setup(repo => repo.SaveChangesAsync())
                .ThrowsAsync(new Exception()); // Simulate an error during the save

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _transactionService.TransferAsync(transferDto));

            // Verify that Rollback is called when an exception is thrown
            _mockTransaction.Verify(t => t.Rollback(), Times.Once);
        }
    }
}
