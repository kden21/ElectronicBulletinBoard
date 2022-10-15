using AutoMapper;
using ElectronicBoard.AppServices.Review.UserReview.Repositories;
using ElectronicBoard.Contracts.Review.UserReview.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Review.UserReview.Services;

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
    public async Task<UserReviewDto> GetUserReviewById(int userReviewId, CancellationToken cancellation)
    {
        var userReviewEntity = await _userReviewRepository.GetUserReviewEntityById(userReviewId, cancellation);
        return _mapper.Map<UserReviewDto>(userReviewEntity);
    }

    /// <inheritdoc />
    public async Task<UserReviewDto> CreateUserReview(UserReviewDto userReviewDto, CancellationToken cancellation)
    {
        var userReviewEntity = _mapper.Map<UserReviewEntity>(userReviewDto);
        var id = await _userReviewRepository.AddUserReviewEntity(userReviewEntity, cancellation);
        userReviewDto.Id = id;
        return userReviewDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<UserReviewDto>> GetAllUserReviews(UserReviewFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<UserReviewEntity>, IEnumerable<UserReviewDto>>(await _userReviewRepository.GetAllUserReviewEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteUserReview(int userReviewId, CancellationToken cancellation)
    {
        await _userReviewRepository.DeleteUserReviewEntity(userReviewId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateUserReview(int userReviewId, UserReviewDto userReviewDto, CancellationToken cancellation)
    {
        userReviewDto.Id = userReviewId;
        var userReview = _mapper.Map<UserReviewEntity>(userReviewDto);
        await _userReviewRepository.UpdateUserReviewEntity(userReview, cancellation);
    }
}