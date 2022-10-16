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
    public async Task<IEnumerable<AdvtEntity>> GetFilterAdvtEntities(AdvtFilterRequest? advtFilter, CancellationToken cancellation)
    {
        var query = _repository.GetAllEntities();
        if (!string.IsNullOrWhiteSpace(advtFilter.Name))
            query = query.Where(a => a.Name.ToLower().Contains(advtFilter.Name.ToLower()));
        if (advtFilter.CategoryId.HasValue)
            query = query.Where(a => a.CategoryId == advtFilter.CategoryId);
        if (advtFilter.UserId.HasValue)
            query = query.Where(a => a.UserId == advtFilter.UserId);
        return await query.Skip(advtFilter.Offset).Take(advtFilter.Count==0?query.Count():advtFilter.Count).ToListAsync(cancellation);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtEntity>> GetAllAdvtEntities(CancellationToken cancellation)
    {
        return _repository.GetAllEntities();
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