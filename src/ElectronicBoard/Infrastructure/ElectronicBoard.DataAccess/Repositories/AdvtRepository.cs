using System.Linq.Expressions;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.DataAccess.Repositories;

public class AdvtRepository : IAdvtRepository
{
    private readonly IRepository<AdvtEntity> _repository;

    public AdvtRepository(IRepository<AdvtEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public IEnumerable<AdvtEntity> GetAllAdvtEntities(AdvtFilterRequest? filterRequest)
    {
        var query = _repository.GetAllEntities();
        if (!string.IsNullOrWhiteSpace(filterRequest.Name))
            query = query.Where(a => a.Name.ToLower().Contains(filterRequest.Name.ToLower()));
        if (filterRequest.CategoryId.HasValue)
            query = query.Where(a => a.CategoryId == filterRequest.CategoryId);
        if (filterRequest.UserId.HasValue)
            query = query.Where(a => a.UserId == filterRequest.UserId);
        return query.OrderBy(a=>a.Id).Skip(filterRequest.Offset).Take(filterRequest.Count);
    }
    
    /// <inheritdoc />
    public async Task<AdvtEntity> GetAdvtEntityById(int advtId)
    {
        return await _repository.GetEntityById(advtId);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtEntity(AdvtEntity advtModel)
    {
        await _repository.AddEntity(advtModel);
        return advtModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtEntity(AdvtEntity advtModel)
    {
        await _repository.UpdateEntity(advtModel);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtEntity(int advtId)
    {
        await _repository.DeleteEntity(advtId);
    }
}