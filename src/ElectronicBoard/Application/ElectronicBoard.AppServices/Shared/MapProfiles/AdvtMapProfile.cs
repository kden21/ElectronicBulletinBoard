using AutoMapper;
using ElectronicBoard.AppServices.Shared.Helpers.PhotoHelper;
using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class AdvtMapProfile : Profile
{
    public AdvtMapProfile()
    {
        CreateMap<AdvtEntity, AdvtDto>()
            .ForMember(ad=>ad.Photos,o=>o.Ignore())
            .ForMember(ad => ad.CreateDate, o => o.MapFrom(src => src.CreateDate.ToString("D")));

        CreateMap<AdvtDto, AdvtEntity>()
            .ForMember(ad => ad.ModifyDate, o => o.Ignore())
            .ForMember(ad => ad.Category, o => o.Ignore())
            .ForMember(ad => ad.Author, o => o.Ignore())
            .ForMember(ad => ad.AdvtReports, o => o.Ignore())
            .ForMember(ad => ad.AdvtReviews, o => o.Ignore())
            .ForMember(ad => ad.CreateDate, o => o.Ignore())
            .ForMember(ad => ad.Photos, o => o.Ignore())
            .ForMember(ad=>ad.UsersVoters, o=>o.Ignore());
    }
}