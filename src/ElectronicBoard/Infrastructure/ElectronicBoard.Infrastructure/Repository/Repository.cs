using System.Linq.Expressions;
using ElectronicBoard.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.Infrastructure.Repository;

/// <inheritdoc />
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected  DbContext DbContext { get; }
    protected DbSet<TEntity> DbSet { get; }
    
    public Repository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<TEntity>();
    }
    
    /// <inheritdoc />
    public IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicat)
    {
        if (predicat == null)
            throw new ArgumentNullException(nameof(predicat));

        return DbSet.Where(predicat);
    }

    /// <inheritdoc />
    public async Task<TEntity?> GetByIdAsync(int TEntityId)
    {
        return await DbSet.FirstOrDefaultAsync(a=> a.Id == TEntityId);
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(TEntity model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));
        
        model.ModifyDate = DateTime.UtcNow;
        var entityEntry = await DbContext.AddAsync(model);
        
        await DbContext.SaveChangesAsync();

        return entityEntry.Entity.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        DbSet.Update(model);
        await DbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        var model = await GetByIdAsync(id);
        if (model == null)
            throw new ArgumentNullException(nameof(model));
        
        DbSet.Remove(model);
        await DbContext.SaveChangesAsync();
    }
    
    public async Task SoftDeleteAsync(TEntity model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));
        
        await UpdateAsync(model);
    }
}