using AutoMapper;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class AdvtMapProfile : Profile
{
    public AdvtMapProfile()
    {
        CreateMap<AdvtEntity, AdvtDto>();
        CreateMap<AdvtDto, AdvtEntity>()
            .ForMember(d => d.ModifyDate, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore())
            .ForMember(d => d.AdvtReports, o => o.Ignore())
            .ForMember(d => d.AdvtReviews, o => o.Ignore());
    }
}