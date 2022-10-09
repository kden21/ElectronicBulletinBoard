using AutoMapper;
using ElectronicBoard.AppServices.Repositories.Review;
using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Services.Review.AdvtReview;

/// <inheritdoc />
public class AdvtReviewService : IAdvtReviewService
{
    private readonly IAdvtReviewRepository _advtReviewRepository;
    private readonly IMapper _mapper;

    public AdvtReviewService(IAdvtReviewRepository advtReviewRepository, IMapper mapper)
    {
        _advtReviewRepository = advtReviewRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<AdvtReviewDto> GetAdvtReviewById(int advtReviewId, CancellationToken cancellation)
    {
        var advtReviewEntity = await _advtReviewRepository.GetAdvtReviewEntityById(advtReviewId, cancellation);
        return _mapper.Map<AdvtReviewDto>(advtReviewEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtReviewDto> CreateAdvtReview(AdvtReviewDto advtReviewDto, CancellationToken cancellation)
    {
        var advtReviewEntity = _mapper.Map<AdvtReviewEntity>(advtReviewDto);
        var id = await _advtReviewRepository.AddAdvtReviewEntity(advtReviewEntity, cancellation);
        advtReviewDto.Id = id;
        return advtReviewDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReviewDto>> GetAllAdvtReviews(AdvtReviewFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtReviewEntity>, IEnumerable<AdvtReviewDto>>(await _advtReviewRepository.GetAllAdvtReviewEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReview(int advtReviewId, CancellationToken cancellation)
    {
        await _advtReviewRepository.DeleteAdvtReviewEntity(advtReviewId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReview(int advtReviewId, AdvtReviewDto advtReviewDto, CancellationToken cancellation)
    {
        advtReviewDto.Id = advtReviewId;
        var advtReview = _mapper.Map<AdvtReviewEntity>(advtReviewDto);
        await _advtReviewRepository.UpdateAdvtReviewEntity(advtReview, cancellation);
    }
}