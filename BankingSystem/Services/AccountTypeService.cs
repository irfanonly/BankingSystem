using AutoMapper;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BankingSystem.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        public readonly IBankAccDBContext _db;
        public readonly IMapper _mapper;
        public AccountTypeService(IBankAccDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(CreateAccountTypeDto accountType)
        {
            var newAccountType = _mapper.Map<AccountType>(accountType);
            _db.AccountTypes.Add(newAccountType);
            await _db.SaveChangesAsync();
            return newAccountType.Id;
        }

        public async Task DeleteAsync(AccountType accountType)
        {
            
            accountType.IsDeleted = true;
            accountType.UpdatedOn = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<AccountType>> GetAsync()
        {
            return await _db.AccountTypes.ToListAsync();
        }

        public async Task<AccountType?> GetAsync(int id)
        {
            return await _db.AccountTypes.FindAsync(id);
        }

        public async Task UpdateAsync(AccountType existingAccountType, UpdateAccountTypeDto newAccountType)
        {
            existingAccountType.UpdatedOn = DateTime.UtcNow;
            existingAccountType.Name = newAccountType.Name;
            await _db.SaveChangesAsync();
        }
    }
}
