using System.Linq.Expressions;

namespace ElectronicBoard.Infrastructure.Repository;

/// <summary>
/// Базовый репозиторий.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Возвращает полный список объектов.
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetAll();
    
    /// <summary>
    /// Возвращает список объектов, проходящих фильтрацию.
    /// </summary>
    /// <param name="predicat">Параметр фильтра.</param>
    /// <returns></returns>
    IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicat);
    
    /// <summary>
    /// Возвращает объект по идентификатору.
    /// </summary>
    /// <param name="TEntityId">Идентификатор</param>
    /// <returns></returns>
    Task<TEntity> GetByIdAsync(int TEntityId);
    
    /// <summary>
    /// Добавляет объект.
    /// </summary>
    /// <param name="model"></param>
    Task AddAsync(TEntity model);
    
    /// <summary>
    /// Обновляет данные объекта.
    /// </summary>
    /// <param name="model"></param>
    Task UpdateAsync(TEntity model);
    
    /// <summary>
    /// Удаляет объект.
    /// </summary>
    /// <param name="model"></param>
    Task DeleteAsync(TEntity model);
}