using AutoMapper;
using ElectronicBoard.AppServices.Review.AdvtReview.Repositories;
using ElectronicBoard.Contracts.Review.AdvtReview.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Review.AdvtReview.Services;

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
    public async Task<IEnumerable<AdvtReviewDto>> GetFilterAdvtReviews(AdvtReviewFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtReviewEntity>, IEnumerable<AdvtReviewDto>>(await _advtReviewRepository.GetFilterAdvtReviewEntities(filterRequest, cancellation));
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReviewDto>> GetAllAdvtReviews(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtReviewEntity>, IEnumerable<AdvtReviewDto>>(await _advtReviewRepository.GetAllAdvtReviewEntities(cancellation));
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