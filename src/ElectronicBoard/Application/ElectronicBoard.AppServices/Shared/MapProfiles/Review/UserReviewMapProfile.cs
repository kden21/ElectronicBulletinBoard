using AutoMapper;
using ElectronicBoard.Contracts.Review.UserReview.Dto;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Review;

public class UserReviewMapProfile : Profile
{
    public UserReviewMapProfile()
    {
        CreateMap<UserReviewEntity, UserReviewDto>()
            .ForMember(ur => ur.CreateDate, o => o.MapFrom(src => src.CreateDate.ToString("D")));
        CreateMap<UserReviewDto, UserReviewEntity>()
            .ForMember(ur => ur.User, o => o.Ignore())
            .ForMember(ur => ur.Author, o => o.Ignore())
            .ForMember(ur => ur.ModifyDate, o => o.Ignore())
            .ForMember(ur => ur.CreateDate, o => o.Ignore());
    }
}