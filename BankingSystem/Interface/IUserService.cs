using BankingSystem.Data;
using BankingSystem.Dtos;

namespace BankingSystem.Interface
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(LoginDto loginDto);
    }
}
