using ElectronicBoard.AppServices.Repositories.Review;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters.Review;
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
    public async Task<IEnumerable<AdvtReviewEntity>> GetAllAdvtReviewEntities(AdvtReviewFilterRequest? advtReviewFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(advtReviewFilter.Count).Skip(advtReviewFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<AdvtReviewEntity?> GetAdvtReviewEntityById(int advtReviewId)
    {
        return await _repository.GetEntityById(advtReviewId);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtReviewEntity(AdvtReviewEntity advtReviewModel)
    {
        await _repository.AddEntity(advtReviewModel);
        return advtReviewModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReviewEntity(AdvtReviewEntity advtReviewModel)
    {
        await _repository.UpdateEntity(advtReviewModel);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReviewEntity(int advtReviewId)
    {
        await _repository.DeleteEntity(advtReviewId);
    }
}