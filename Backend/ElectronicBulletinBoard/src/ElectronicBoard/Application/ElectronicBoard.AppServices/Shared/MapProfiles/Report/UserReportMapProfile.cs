using AutoMapper;
using ElectronicBoard.Contracts.Report.UserReport.Dto;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Report;

public class UserReportMapProfile : Profile
{
    public UserReportMapProfile()
    {
        CreateMap<UserReportEntity, UserReportDto>()
            .ForMember(ur => ur.CreateDate, o => o.MapFrom(src => src.CreateDate.ToString("D")));

        CreateMap<UserReportDto, UserReportEntity>()
            //.ForMember(ar => ar.Id, o => o.Ignore())
            .ForMember(ur => ur.Author, o => o.Ignore())
            .ForMember(ur => ur.User, o => o.Ignore())
            .ForMember(ur => ur.ModifyDate, o => o.Ignore())
            .ForMember(ur => ur.CategoryReport, o => o.Ignore())
            .ForMember(ur => ur.CreateDate, o => o.Ignore());
    }
}