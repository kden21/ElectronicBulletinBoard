using System.Linq.Expressions;
using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.DataAccess.Repositories.Shared;
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
    public IQueryable<AdvtEntity> GetAll()
    {
       return _repository.GetAll();
    }

    /// <inheritdoc />
    public IQueryable<AdvtEntity> GetAllFiltered(Expression<Func<AdvtEntity, bool>> predicat)
    {
        return _repository.GetAllFiltered(predicat);
    }

    /// <inheritdoc />
    public async Task<AdvtEntity?> GetByIdAsync(int advtId)
    {
        return await _repository.GetByIdAsync(advtId);
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(AdvtEntity model)
    {
        await _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(AdvtEntity model)
    {
        await _repository.UpdateAsync(model);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}