using AutoMapper;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Domain;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Report;

public class AdvtReportMapProfile : Profile
{
    public AdvtReportMapProfile()
    {
        CreateMap<AdvtReportEntity, AdvtReportDto>();
        
        CreateMap<AdvtReportDto, AdvtReportEntity>()
            .ForMember(ar => ar.Author, o => o.Ignore())
            .ForMember(ar => ar.Advt, o => o.Ignore())
            .ForMember(ar => ar.ModifyDate, o => o.Ignore())
            .ForMember(ur => ur.CategoryReport, o => o.Ignore());
    }
}