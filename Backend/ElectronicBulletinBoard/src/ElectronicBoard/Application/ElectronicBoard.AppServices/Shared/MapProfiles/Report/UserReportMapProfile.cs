using System.Globalization;
using AutoMapper;
using ElectronicBoard.Contracts.Report.UserReport.Dto;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Report;

public class UserReportMapProfile : Profile
{
    public UserReportMapProfile()
    {
        CreateMap<UserReportEntity, UserReportDto>()
            .ForMember(ur => ur.CreateDate, o => o.MapFrom(src => src.CreateDate.ToString("yyyy-MM-dd")));

        CreateMap<UserReportDto, UserReportEntity>()
            .ForMember(ur => ur.Author, o => o.Ignore())
            .ForMember(ur => ur.User, o => o.Ignore())
            .ForMember(ur => ur.ModifyDate, o => o.Ignore())
            .ForMember(ur => ur.CategoryReport, o => o.Ignore())
            .ForMember(ar => ar.CreateDate, o =>
                o.MapFrom(src => DateTime.ParseExact(src.CreateDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture))); }
}