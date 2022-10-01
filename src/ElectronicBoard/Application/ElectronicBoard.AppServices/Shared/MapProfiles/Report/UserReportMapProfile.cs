using AutoMapper;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Report;

public class UserReportMapProfile : Profile
{
    public UserReportMapProfile()
    {
        CreateMap<UserReportEntity, UserReportDto>();

        CreateMap<UserReportDto, UserReportEntity>()
            .ForMember(ar => ar.Author, o => o.Ignore())
            .ForMember(ar => ar.User, o => o.Ignore())
            .ForMember(ar => ar.ModifyDate, o => o.Ignore())
            .ForMember(ur => ur.CategoryReport, o => o.Ignore());
    }
}