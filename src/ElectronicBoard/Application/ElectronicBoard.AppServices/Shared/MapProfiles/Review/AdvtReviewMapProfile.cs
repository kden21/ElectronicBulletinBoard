using AutoMapper;
using ElectronicBoard.Contracts.Review.AdvtReview.Dto;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Review;

public class AdvtReviewMapProfile : Profile
{
    public AdvtReviewMapProfile()
    {
        CreateMap<AdvtReviewEntity, AdvtReviewDto>();
        CreateMap<AdvtReviewDto, AdvtReviewEntity>()
            .ForMember(ar => ar.Advt, o => o.Ignore())
            .ForMember(ar => ar.Author, o => o.Ignore())
            .ForMember(ar => ar.ModifyDate, o => o.Ignore());
    }
}