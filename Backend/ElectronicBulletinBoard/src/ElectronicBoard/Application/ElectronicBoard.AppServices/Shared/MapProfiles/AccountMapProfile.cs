using AutoMapper;
using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.Account.RegisterAccount;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class AccountMapProfile : Profile
{
    public AccountMapProfile()
    {
        CreateMap<AccountEntity, AccountDto>();

        CreateMap<AccountDto, AccountEntity>()
            .ForMember(a => a.ModifyDate, o => o.Ignore())
            .ForMember(a => a.User, o => o.Ignore())
            .ForMember(a => a.CreateDate, o => o.Ignore());

        CreateMap<RegisterRequest, AccountEntity>()
            .ForMember(a => a.Id, o => o.Ignore())
            .ForMember(a => a.ModifyDate, o => o.Ignore())
            .ForMember(a => a.CreateDate, o => o.Ignore())
            .ForMember(a => a.User, o => o.Ignore())
            .ForMember(a=>a.UserCode, o=>o.Ignore());
    }
}