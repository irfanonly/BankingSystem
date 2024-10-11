using AutoMapper;
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
    public class AccountServiceTests
    {
        private readonly Mock<IGenericRepository<Account>> _mockAccountRepository;
        private readonly Mock<IGenericRepository<AccountType>> _mockAccountTypeRepository;
        private readonly Mock<IGenericRepository<ClosedAccount>> _mockClosedAccountRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AccountService _accountService;
        private readonly Mock<IDbContextTransaction> _mockTransaction;
        public AccountServiceTests()
        {
            _mockAccountRepository = new Mock<IGenericRepository<Account>>();
            _mockAccountTypeRepository = new Mock<IGenericRepository<AccountType>>();
            _mockClosedAccountRepository = new Mock<IGenericRepository<ClosedAccount>>();
            _mockMapper = new Mock<IMapper>();
            _accountService = new AccountService(
                _mockAccountRepository.Object,
                _mockMapper.Object,
                _mockAccountTypeRepository.Object,
                _mockClosedAccountRepository.Object);
            _mockTransaction = new Mock<IDbContextTransaction>();
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowNotFoundException_WhenAccountTypeDoesNotExist()
        {
            // Arrange
            var createAccountDto = new CreateAccountDto { AccountTypeId = 1 };
            _mockAccountTypeRepository.Setup(repo => repo.FindAsync(createAccountDto.AccountTypeId))
                .ReturnsAsync((AccountType)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _accountService.CreateAsync(createAccountDto));
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowBadRequestException_WhenOverdraftLimitIsMissingForCheckingAccount()
        {
            // Arrange
            var accountType = new AccountType { Name = AccountType.Checking };
            var createAccountDto = new CreateAccountDto { AccountTypeId = 1, OverDraftLimit = null };

            _mockAccountTypeRepository.Setup(repo => repo.FindAsync(createAccountDto.AccountTypeId))
                .ReturnsAsync(accountType);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _accountService.CreateAsync(createAccountDto));
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowBadRequestException_WhenOverdraftLimitIsNotApplicableForOtherAccountTypes()
        {
            // Arrange
            var accountType = new AccountType { Name = "Savings" };
            var createAccountDto = new CreateAccountDto { AccountTypeId = 1, OverDraftLimit = 1000 };

            _mockAccountTypeRepository.Setup(repo => repo.FindAsync(createAccountDto.AccountTypeId))
                .ReturnsAsync(accountType);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _accountService.CreateAsync(createAccountDto));
        }

        [Fact]
        public async Task CreateAsync_ShouldAddAccount_WhenValidAccountDataIsProvided()
        {
            // Arrange
            var createAccountDto = new CreateAccountDto { AccountTypeId = 1, OverDraftLimit = null };
            var accountType = new AccountType { Name = "Savings" };
            var newAccount = new Account { Id = Guid.NewGuid(), Name = "New Account" };

            _mockAccountTypeRepository.Setup(repo => repo.FindAsync(createAccountDto.AccountTypeId))
                .ReturnsAsync(accountType);
            _mockMapper.Setup(mapper => mapper.Map<Account>(createAccountDto))
                .Returns(newAccount);
            _mockAccountRepository.Setup(repo => repo.AddAsync(newAccount))
                .Returns(Task.CompletedTask);
            _mockAccountRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _accountService.CreateAsync(createAccountDto);

            // Assert
            Assert.Equal(newAccount.Id, result);
            _mockAccountRepository.Verify(repo => repo.AddAsync(It.IsAny<Account>()), Times.Once);
            _mockAccountRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetDtoAsync_ShouldThrowNotFoundException_WhenAccountIsNotFound()
        {
            // Arrange
            _mockAccountRepository.Setup(repo => repo.GetWithIncludeAsync(It.IsAny<Expression<Func<Account, object>>>()))
                .ReturnsAsync((IEnumerable<Account>)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _accountService.GetDtoAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task CloseAsync_ShouldThrowNotFoundException_WhenAccountIsNotFound()
        {
            // Arrange
            _mockAccountRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Account)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _accountService.CloseAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task CloseAsync_ShouldMarkAccountAsClosedAndAddToClosedAccount_WhenAccountExists()
        {
            // Arrange
            var account = new Account { Id = Guid.NewGuid(), IsClosed = false };
            var closedAccount = new ClosedAccount { AccountId = account.Id, ClosedOn = DateTime.UtcNow };

            _mockAccountRepository.Setup(repo => repo.BeginTransactionAsync())
            .ReturnsAsync(_mockTransaction.Object);

            _mockAccountRepository.Setup(repo => repo.GetByIdAsync(account.Id))
                .ReturnsAsync(account);
            _mockClosedAccountRepository.Setup(repo => repo.AddAsync(It.IsAny<ClosedAccount>()))
                .Returns(Task.CompletedTask);
            _mockAccountRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            await _accountService.CloseAsync(account.Id);

            // Assert
            Assert.True(account.IsClosed);
            _mockClosedAccountRepository.Verify(repo => repo.AddAsync(It.IsAny<ClosedAccount>()), Times.Once);
            _mockAccountRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}
