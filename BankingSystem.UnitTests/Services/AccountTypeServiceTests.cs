using AutoMapper;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Exceptions;
using BankingSystem.Interface;
using BankingSystem.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Services
{
    public class AccountTypeServiceTests
    {
        private readonly Mock<IGenericRepository<AccountType>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AccountTypeService _accountTypeService;

        public AccountTypeServiceTests()
        {
            _mockRepository = new Mock<IGenericRepository<AccountType>>();
            _mockMapper = new Mock<IMapper>();
            _accountTypeService = new AccountTypeService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowBadRequestException_WhenAccountTypeAlreadyExists()
        {
            // Arrange
            var createDto = new CreateAccountTypeDto { Name = "Savings" };
            _mockRepository.Setup(repo => repo.Any(It.IsAny<Expression<Func<AccountType, bool>>>()))
                           .Returns(true);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _accountTypeService.CreateAsync(createDto));
        }

        [Fact]
        public async Task CreateAsync_ShouldAddAccountType_WhenAccountTypeDoesNotExist()
        {
            // Arrange
            var createDto = new CreateAccountTypeDto { Name = "Savings" };
            var newAccountType = new AccountType { Id = 1, Name = "Savings" };

            _mockRepository.Setup(repo => repo.Any(It.IsAny<Expression<Func<AccountType, bool>>>()))
                           .Returns(false);
            _mockMapper.Setup(mapper => mapper.Map<AccountType>(createDto))
                       .Returns(newAccountType);
            _mockRepository.Setup(repo => repo.AddAsync(newAccountType))
                           .Returns(Task.CompletedTask);
            _mockRepository.Setup(repo => repo.SaveChangesAsync())
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _accountTypeService.CreateAsync(createDto);

            // Assert
            Assert.Equal(1, result);
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<AccountType>()), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenAccountTypeNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<int>()))
                           .ReturnsAsync((AccountType)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _accountTypeService.DeleteAsync(1));
        }

        [Fact]
        public async Task DeleteAsync_ShouldMarkAccountTypeAsDeleted_WhenAccountTypeIsFound()
        {
            // Arrange
            var existingAccountType = new AccountType { Id = 1, IsDeleted = false };

            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<int>()))
                           .ReturnsAsync(existingAccountType);
            _mockRepository.Setup(repo => repo.SaveChangesAsync())
                           .Returns(Task.CompletedTask);

            // Act
            await _accountTypeService.DeleteAsync(1);

            // Assert
            Assert.True(existingAccountType.IsDeleted);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenAccountTypeNotFound()
        {
            // Arrange
            var updateDto = new UpdateAccountTypeDto { Id = 1, Name = "UpdatedName" };

            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<int>()))
                           .ReturnsAsync((AccountType)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _accountTypeService.UpdateAsync(updateDto));
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateAccountType_WhenAccountTypeIsFound()
        {
            // Arrange
            var existingAccountType = new AccountType { Id = 1, Name = "CurrentName" };
            var updateDto = new UpdateAccountTypeDto { Id = 1, Name = "UpdatedName" };

            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<int>()))
                           .ReturnsAsync(existingAccountType);
            _mockRepository.Setup(repo => repo.SaveChangesAsync())
                           .Returns(Task.CompletedTask);

            // Act
            await _accountTypeService.UpdateAsync(updateDto);

            // Assert
            Assert.Equal("UpdatedName", existingAccountType.Name);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }

}
