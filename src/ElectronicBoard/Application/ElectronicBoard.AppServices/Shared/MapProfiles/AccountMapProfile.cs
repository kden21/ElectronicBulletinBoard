using AutoMapper;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class AccountMapProfile : Profile
{
    public AccountMapProfile()
    {
        CreateMap<AccountEntity, AccountDto>();

        CreateMap<AccountDto, AccountEntity>()
            .ForMember(a => a.ModifyDate, o => o.Ignore())
            .ForMember(a => a.User, o => o.Ignore());
        
        //CreateMap<>()
    }
}