using AutoMapper;
using ElectronicBoard.Contracts.Report.CategoryReport.Dto;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.Report;

public class CategoryReportMapProfile : Profile
{
    public CategoryReportMapProfile()
    {
        CreateMap<CategoryReportEntity, CategoryReportDto>();

        CreateMap<CategoryReportDto, CategoryReportEntity>()
            .ForMember(cr => cr.ModifyDate, o => o.Ignore());
    }
}