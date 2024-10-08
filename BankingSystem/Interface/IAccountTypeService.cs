using BankingSystem.Data;
using BankingSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Interface
{
    public interface IAccountTypeService
    {
        Task<int> CreateAsync(CreateAccountTypeDto account);
        Task DeleteAsync(AccountType accountType);
        Task<IEnumerable<AccountType>> GetAsync();
        Task<AccountType?> GetAsync(int Id);
        Task UpdateAsync(AccountType existingAccountType, UpdateAccountTypeDto newAccountType);
    }
}
