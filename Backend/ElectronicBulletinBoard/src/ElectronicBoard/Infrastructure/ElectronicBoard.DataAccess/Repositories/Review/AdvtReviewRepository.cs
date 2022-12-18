using ElectronicBoard.AppServices.Review.AdvtReview.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters.Review;
using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Review;

/// <inheritdoc />
public class AdvtReviewRepository : IAdvtReviewRepository
{
    private readonly IRepository<AdvtReviewEntity> _repository;

    public AdvtReviewRepository(IRepository<AdvtReviewEntity> repository)
    {
        _repository = repository;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReviewEntity>> GetFilterAdvtReviewEntities(AdvtReviewFilterRequest? advtReviewFilter, CancellationToken cancellation)
    {
       return await _repository.GetAllEntities().OrderByDescending(ar => ar.Id)
            .Where(ar => ar.AdvtId == advtReviewFilter!.AdvtId).ToListAsync(cancellation);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReviewEntity>> GetAllAdvtReviewEntities(CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<AdvtReviewEntity?> GetAdvtReviewEntityById(int advtReviewId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(advtReviewId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtReviewEntity(AdvtReviewEntity advtReviewModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(advtReviewModel, cancellation);
        return advtReviewModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReviewEntity(AdvtReviewEntity advtReviewModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(advtReviewModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReviewEntity(int advtReviewId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtReviewId, cancellation);
    }
}