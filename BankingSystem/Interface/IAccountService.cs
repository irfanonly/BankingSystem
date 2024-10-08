using BankingSystem.Data;
using BankingSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Interface
{
    public interface IAccountService
    {
        Task<Guid> CreateAsync(CreateAccountDto account);
        Task<AccountDto?> GetAsync(Guid id);
    }
}
