using AutoMapper;
using ElectronicBoard.AppServices.Repositories.Review;
using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Services.Review;

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
    public async Task<AdvtReviewDto> GetAdvtReviewById(int advtReviewId)
    {
        var advtReviewEntity = await _advtReviewRepository.GetAdvtReviewEntityById(advtReviewId);
        return _mapper.Map<AdvtReviewDto>(advtReviewEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtReviewDto> CreateAdvtReview(AdvtReviewDto advtReviewDto)
    {
        var advtReviewEntity = _mapper.Map<AdvtReviewEntity>(advtReviewDto);
        var id = await _advtReviewRepository.AddAdvtReviewEntity(advtReviewEntity);
        advtReviewDto.Id = id;
        return advtReviewDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReviewDto>> GetAllAdvtReviews(AdvtReviewFilterRequest? filterRequest)
    {
        return _mapper.Map<IEnumerable<AdvtReviewEntity>, IEnumerable<AdvtReviewDto>>(await _advtReviewRepository.GetAllAdvtReviewEntities(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReview(int advtReviewId)
    {
        await _advtReviewRepository.DeleteAdvtReviewEntity(advtReviewId);
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReview(int advtReviewId, AdvtReviewDto advtReviewDto)
    {
        advtReviewDto.Id = advtReviewId;
        var advtReview = _mapper.Map<AdvtReviewEntity>(advtReviewDto);
        await _advtReviewRepository.UpdateAdvtReviewEntity(advtReview);
    }
}