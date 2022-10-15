using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

public class AdvtRepository : IAdvtRepository
{
    private readonly IRepository<AdvtEntity> _repository;

    public AdvtRepository(IRepository<AdvtEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AdvtEntity>> GetAllAdvtEntities(AdvtFilterRequest? filterRequest, CancellationToken cancellation)
    {
        var query = _repository.GetAllEntities();
        if (!string.IsNullOrWhiteSpace(filterRequest.Name))
            query = query.Where(a => a.Name.ToLower().Contains(filterRequest.Name.ToLower()));
        if (filterRequest.CategoryId.HasValue)
            query = query.Where(a => a.CategoryId == filterRequest.CategoryId);
        if (filterRequest.UserId.HasValue)
            query = query.Where(a => a.UserId == filterRequest.UserId);
        return await query.OrderBy(a=>a.Id).Skip(filterRequest.Offset).Take(filterRequest.Count).ToListAsync(cancellation);
    }
    
    /// <inheritdoc />
    public async Task<AdvtEntity> GetAdvtEntityById(int advtId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(advtId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(advtModel, cancellation);
        return advtModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(advtModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtEntity(int advtId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtId, cancellation);
    }
}