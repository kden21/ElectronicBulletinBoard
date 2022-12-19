using AutoMapper;
using ElectronicBoard.AppServices.Shared.Helpers.PhotoHelper;
using ElectronicBoard.Contracts.Photo;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class PhotoMapProfile: Profile
{
    public PhotoMapProfile()
    {
        CreateMap<PhotoEntity, PhotoDto>()
            .ForMember(p=>p.Base64Str, o=>o.MapFrom(src=>PhotoHelpers.ConvertToBase64(src.Photo!)));
        CreateMap<PhotoDto, PhotoEntity>()
            .ForMember(p => p.Photo, o => o.MapFrom(src => PhotoHelpers.ConvertToBytes(src.Base64Str)))
            .ForMember(p => p.Advt, o => o.Ignore())
            .ForMember(p => p.CreateDate, o => o.Ignore())
            .ForMember(p => p.ModifyDate, o => o.Ignore());
    }
}