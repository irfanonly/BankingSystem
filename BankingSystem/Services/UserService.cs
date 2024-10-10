using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
using System.Runtime.CompilerServices;

namespace BankingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _db;

        public UserService(IGenericRepository<User> db)
        {
            _db = db;
        }
        public async Task<User?> GetUserAsync(LoginDto loginDto)
        {
            //TODO: password should be hashed
            var users =  await _db.FindAsync(x => x.Email == loginDto.Username
            && x.Password == loginDto.Password);

            return users?.FirstOrDefault();
            
        }
    }
}
