using AutoMapper;
using BankingSystem.Data;
using BankingSystem.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAccountDto, Account>();
        CreateMap<Account, CreateAccountDto>();

        CreateMap<CreateAccountTypeDto, AccountType>();
        //CreateMap<GetAccountTypeDto, AccountType>();
    }
}
