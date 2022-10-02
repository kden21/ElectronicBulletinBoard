using AutoMapper;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<UserEntity, UserDto>();
        CreateMap<UserDto, UserEntity>()
            .ForMember(d => d.MiddleName, o => o.Ignore())
            .ForMember(d => d.ModifyDate, o => o.Ignore())
            .ForMember(d => d.Advts, o => o.Ignore())
            .ForMember(d => d.UserReviews, o => o.Ignore())
            .ForMember(d => d.AuthorUserReviews, o => o.Ignore())
            .ForMember(d => d.AuthorAdvtReviews, o => o.Ignore())
            .ForMember(d => d.UserReports, o => o.Ignore())
            .ForMember(d => d.AuthorUserReports, o => o.Ignore())
            .ForMember(d => d.AuthorAdvtReports, o => o.Ignore())
            .ForMember(d => d.Account, o => o.Ignore());
        
    }
}