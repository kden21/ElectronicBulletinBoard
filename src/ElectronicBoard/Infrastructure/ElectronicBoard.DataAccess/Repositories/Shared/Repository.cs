using System.Linq.Expressions;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.DataAccess.Exceptions;
using ElectronicBoard.Domain.Shared;
using ElectronicBoard.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Shared;

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
            throw new EntityNotFoundException($"Пустой фильтр '{predicat}'");
        
        return DbSet.Where(predicat);
    }

    /// <inheritdoc />
    public async Task<TEntity> GetByIdAsync(int TEntityId)
    {
        var entity = await DbSet.FirstOrDefaultAsync(a=> a.Id == TEntityId);
        if(entity == null)
            throw new EntityNotFoundException($"Не существует сущности с идентификатором '{TEntityId}'");
        return entity;
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(TEntity model)
    {
        if (model == null)
            throw new EntityNotFoundException($"Модель представления не может быть null");
        
        var entityEntry = await DbContext.AddAsync(model);
        model.ModifyDate = DateTime.UtcNow;
        try
        {
            await DbContext.SaveChangesAsync();
        }
        catch(Exception exception)
        {
            throw new EntityCreateException("Не удалось добавить сущность в БД");
        }

        return entityEntry.Entity.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity model)
    {
        if (model == null)
            throw new EntityNotFoundException($"Модель представления не может быть null");
        try
        {
            DbSet.Update(model);
            await DbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw new EntityUpdateException("Не удалось обновить сущность");
        }
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int TEntityId)
    {
        var model = await GetByIdAsync(TEntityId);
        if (model == null)
            throw new EntityNotFoundException($"Не удалось удалить сущность с идентификатором '{TEntityId}', т.к. она не была найдена в БД");
        
        DbSet.Remove(model);
        await DbContext.SaveChangesAsync();
    }
    
    //TODO: доработать "мягкое удаление"
    public async Task SoftDeleteAsync(TEntity model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));
        
        await UpdateAsync(model);
    }
}