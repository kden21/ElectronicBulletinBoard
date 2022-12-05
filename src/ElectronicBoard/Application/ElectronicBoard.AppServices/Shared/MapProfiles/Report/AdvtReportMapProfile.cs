using AutoMapper;
using ElectronicBoard.Contracts.Report.AdvtReport.Dto;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Report;

public class AdvtReportMapProfile : Profile
{
    public AdvtReportMapProfile()
    {
        CreateMap<AdvtReportEntity, AdvtReportDto>()
            .ForMember(ar => ar.CreateDate, o => o.MapFrom(src => src.CreateDate.ToString("D")));

        CreateMap<AdvtReportDto, AdvtReportEntity>()
            .ForMember(ar => ar.Author, o => o.Ignore())
            .ForMember(ar => ar.Advt, o => o.Ignore())
            .ForMember(ar => ar.ModifyDate, o => o.Ignore())
            .ForMember(ur => ur.CategoryReport, o => o.Ignore())
            .ForMember(ar => ar.CreateDate, o => o.Ignore());
    }
}