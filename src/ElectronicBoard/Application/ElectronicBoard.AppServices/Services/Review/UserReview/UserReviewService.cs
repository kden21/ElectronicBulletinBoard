using AutoMapper;
using ElectronicBoard.AppServices.Repositories.Review;
using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Services.Review.UserReview;

/// <inheritdoc />
public class UserReviewService : IUserReviewService
{
    private readonly IUserReviewRepository _userReviewRepository;
    private readonly IMapper _mapper;

    public UserReviewService(IUserReviewRepository userReviewRepository, IMapper mapper)
    {
        _userReviewRepository = userReviewRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<UserReviewDto> GetUserReviewById(int userReviewId)
    {
        var userReviewEntity = await _userReviewRepository.GetUserReviewEntityById(userReviewId);
        return _mapper.Map<UserReviewDto>(userReviewEntity);
    }

    /// <inheritdoc />
    public async Task<UserReviewDto> CreateUserReview(UserReviewDto userReviewDto)
    {
        var userReviewEntity = _mapper.Map<UserReviewEntity>(userReviewDto);
        var id = await _userReviewRepository.AddUserReviewEntity(userReviewEntity);
        userReviewDto.Id = id;
        return userReviewDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<UserReviewDto>> GetAllUserReviews(UserReviewFilterRequest? filterRequest)
    {
        return _mapper.Map<IEnumerable<UserReviewEntity>, IEnumerable<UserReviewDto>>(await _userReviewRepository.GetAllUserReviewEntities(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteUserReview(int userReviewId)
    {
        await _userReviewRepository.DeleteUserReviewEntity(userReviewId);
    }

    /// <inheritdoc />
    public async Task UpdateUserReview(int userReviewId, UserReviewDto userReviewDto)
    {
        userReviewDto.Id = userReviewId;
        var userReview = _mapper.Map<UserReviewEntity>(userReviewDto);
        await _userReviewRepository.UpdateUserReviewEntity(userReview);
    }
}