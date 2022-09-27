using System.Linq.Expressions;
using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.Domain;
using ElectronicBoard.Infrastructure.Repository;

namespace ElectronicBoard.DataAccess.Repositories;

public class AdvtRepository : IAdvtRepository
{
    private readonly IRepository<AdvtEntity> _repository;

    public AdvtRepository(IRepository<AdvtEntity> repository)
    {
        _repository = repository;
    }

    public IQueryable<AdvtEntity> GetAll()
    {
       return _repository.GetAll();
    }

    public IQueryable<AdvtEntity> GetAllFiltered(Expression<Func<AdvtEntity, bool>> predicat)
    {
        return _repository.GetAllFiltered(predicat);
    }

    public async Task<AdvtEntity> GetByIdAsync(int advtId)
    {
        return await _repository.GetByIdAsync(advtId);
    }

    public async Task AddAsync(AdvtEntity model)
    {
        await _repository.AddAsync(model);
    }

    public async Task UpdateAsync(AdvtEntity model)
    {
        await _repository.UpdateAsync(model);
    }

    public async Task DeleteAsync(AdvtEntity model)
    {
        await _repository.DeleteAsync(model);
    }
}