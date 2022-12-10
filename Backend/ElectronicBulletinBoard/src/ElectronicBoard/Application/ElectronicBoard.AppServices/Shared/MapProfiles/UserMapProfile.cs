using System.Globalization;
using AutoMapper;
using ElectronicBoard.AppServices.Shared.Helpers.PhotoHelper;
using ElectronicBoard.Contracts.User.Dto;
using ElectronicBoard.Domain;
using ElectronicBoard.Contracts.Account.RegisterAccount;

namespace ElectronicBoard.AppServices.Shared.MapProfiles;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<UserEntity, UserDto>()
            .ForMember(u => u.Birthday, o => o.MapFrom(src => src.Birthday.ToString()))
            .ForMember(u => u.Photo, o => o.MapFrom(src=>
                PhotoHelpers.ConvertToBase64(src.Photo)))
            .ForMember(u => u.CreateDate, o => o.MapFrom(src => src.CreateDate.ToString("D")));
        CreateMap<UserDto, UserEntity>()

            .ForMember(u => u.ModifyDate, o => o.Ignore())
            .ForMember(u => u.Advts, o => o.Ignore())
            .ForMember(u => u.UserReviews, o => o.Ignore())
            .ForMember(u => u.AuthorUserReviews, o => o.Ignore())
            .ForMember(u => u.AuthorAdvtReviews, o => o.Ignore())
            .ForMember(u => u.UserReports, o => o.Ignore())
            .ForMember(u => u.AuthorUserReports, o => o.Ignore())   
            .ForMember(u => u.AuthorAdvtReports, o => o.Ignore())
            .ForMember(u => u.Account, o => o.Ignore())
            .ForMember(u => u.CreateDate, o => o.Ignore())
            .ForMember(u => u.Birthday, o =>
                o.MapFrom(src =>
                    DateTime.ParseExact(src.Birthday, "ddMMyyyy",
                        CultureInfo.InvariantCulture)))
            //.ForMember(u => u.Birthday, o => 
               // o.MapFrom(src => DateHelper.ToDateTime(src.Birthday)))
            .ForMember(u => u.Id, o => o.Ignore())
            .ForMember(ad => ad.Photo, o => 
                o.MapFrom(src=>PhotoHelpers.ConvertToBytes(src.Photo)))
            .ForMember(ad=>ad.FavoriteAdvts, o=>o.Ignore());


        CreateMap<RegisterRequest, UserEntity>()

            .ForMember(u => u.ModifyDate, o => o.Ignore())
            .ForMember(u => u.Advts, o => o.Ignore())
            .ForMember(u => u.UserReviews, o => o.Ignore())
            .ForMember(u => u.AuthorUserReviews, o => o.Ignore())
            .ForMember(u => u.AuthorAdvtReviews, o => o.Ignore())
            .ForMember(u => u.UserReports, o => o.Ignore())
            .ForMember(u => u.AuthorUserReports, o => o.Ignore())
            .ForMember(u => u.AuthorAdvtReports, o => o.Ignore())
            .ForMember(u => u.Account, o => o.Ignore())
            .ForMember(u => u.CreateDate, o => o.Ignore())
            .ForMember(u => u.Birthday, o =>
                o.MapFrom(src =>
                    DateTime.ParseExact(src.Birthday, "ddMMyyyy",
                        CultureInfo.InvariantCulture))) //DateHelper.ToDateTime(src.Birthday)))
            .ForMember(u => u.Id, o => o.Ignore())
            .ForMember(ad => ad.Photo, o => o.Ignore())
            .ForMember(u => u.FavoriteAdvts, o => o.Ignore());
    }
}