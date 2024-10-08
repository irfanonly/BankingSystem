using BankingSystem.Dtos;

namespace BankingSystem.Interface
{
    public interface IAccountTypeService
    {
        Task<int> CreateAsync(CreateAccountTypeDto account);
    }
}
