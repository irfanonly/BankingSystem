﻿using AutoMapper;
using BankingSystem.Data;
using BankingSystem.Dtos;
using BankingSystem.Exceptions;
using BankingSystem.Interface;


namespace BankingSystem.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        public readonly IGenericRepository<AccountType> _db;
        public readonly IMapper _mapper;
        public AccountTypeService(IGenericRepository<AccountType> db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(CreateAccountTypeDto accountType)
        {
            if (_db.Any(x => x.Name == accountType.Name))
            {
                throw new BadRequestException("The account type is already exists");
            }

            var newAccountType = _mapper.Map<AccountType>(accountType);

            await _db.AddAsync(newAccountType);
            await _db.SaveChangesAsync();
            return newAccountType.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var accType = await _db.FindAsync(id);

            if (accType == null)
            {
                throw new NotFoundException("The account type is not found");
            }

            accType.IsDeleted = true;
            accType.UpdatedOn = DateTime.UtcNow;

            await _db.SaveChangesAsync();

        }


        public async Task<IEnumerable<AccountType>> GetAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<AccountType?> GetAsync(int id)
        {
            var accType =  await _db.FindAsync(id);

            if (accType == null)
            {
                throw new NotFoundException("The account type is not found");
            }

            return accType;

        }

        public async Task UpdateAsync(UpdateAccountTypeDto newAccountType)
        {
            var accType = await _db.FindAsync(newAccountType.Id);
            if (accType == null)
            {
                throw new NotFoundException("The account type is not found");
            }

            accType.UpdatedOn = DateTime.UtcNow;
            accType.Name = newAccountType.Name;
            await _db.SaveChangesAsync();
        }

    }
}
