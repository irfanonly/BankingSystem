using AutoMapper;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Interface;

namespace BankingSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IBankAccDBContext _db;
        private readonly IMapper _mapper;
        public AccountService(IBankAccDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Guid> CreateAsync(CreateAccountDto account)
        {
            var newAccount = _mapper.Map<Account>(account);
            _db.Accounts.Add(newAccount);
            await _db.SaveChangesAsync();
            return newAccount.AccountId;
        }
    }
}
