using BankingSystem.Data;
using BankingSystem.Dtos;

namespace BankingSystem.Interface
{
    public interface IAccountService
    {
        Task<Guid> CreateAsync(CreateAccountDto account);
    }
}
