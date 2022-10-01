using AutoMapper;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Report;

public class CategoryReportMapProfile : Profile
{
    public CategoryReportMapProfile()
    {
        CreateMap<CategoryReportEntity, CategoryReportDto>();

        CreateMap<CategoryReportDto, CategoryReportEntity>()
            .ForMember(cr => cr.ModifyDate, o => o.Ignore());
    }
}