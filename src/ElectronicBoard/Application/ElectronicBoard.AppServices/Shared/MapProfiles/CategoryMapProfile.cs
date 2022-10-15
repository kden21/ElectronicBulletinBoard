using AutoMapper;
using ElectronicBoard.Contracts.Category.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class CategoryMapProfile : Profile
{
    public CategoryMapProfile()
    {
        CreateMap<CategoryEntity, CategoryDto>();
        CreateMap<CategoryDto, CategoryEntity>()
            .ForMember(c => c.ParentCategory, o => o.Ignore())
            .ForMember(c => c.ChildCategories, o => o.Ignore())
            .ForMember(c => c.Advts, o => o.Ignore())
            .ForMember(c => c.ModifyDate, o => o.Ignore());
    }
}