using BankingSystem.Data;
using BankingSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Interface
{
    public interface IAccountService
    {
        Task CloseAsync(Guid Id);
        Task<Guid> CreateAsync(CreateAccountDto account);
        Task<AccountDto?> GetDtoAsync(Guid id);
        Task<Account?> GetAsync(Guid id);
    }
}
