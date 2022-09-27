using System.Linq.Expressions;
using ElectronicBoard.Domain;
using ElectronicBoard.Infrastructure.Repository;

namespace ElectronicBoard.AppServices.Advt.Repositories;

public interface IAdvtRepository
{
    public IQueryable<AdvtEntity> GetAll();

    public IQueryable<AdvtEntity> GetAllFiltered(Expression<Func<AdvtEntity, bool>> predicat);

    public Task<AdvtEntity> GetByIdAsync(int advtId);

    public Task AddAsync(AdvtEntity model);

    public Task UpdateAsync(AdvtEntity model);

    public Task DeleteAsync(AdvtEntity model);
}
