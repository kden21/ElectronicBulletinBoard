using System.Linq.Expressions;

namespace ElectronicBoard.AppServices.Shared.Repository;

/// <summary>
/// Базовый репозиторий.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Возвращает полный список объектов.
    /// </summary>
    /// <returns>Коллекция объектов.</returns>
    IQueryable<TEntity> GetAll();
    
    /// <summary>
    /// Возвращает список объектов, проходящих фильтрацию.
    /// </summary>
    /// <param name="predicat">Параметр фильтра.</param>
    /// <returns>Коллекция объектов.</returns>
    IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicat);
    
    /// <summary>
    /// Возвращает объект по идентификатору.
    /// </summary>
    /// <param name="TEntityId">Идентификатор.</param>
    /// <returns>Объект TEntity.</returns>
    Task<TEntity> GetByIdAsync(int TEntityId);
    
    /// <summary>
    /// Добавляет объект.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    /// <returns>Идентификатор объекта.</returns>
    Task<int> AddAsync(TEntity model);
    
    /// <summary>
    /// Обновляет данные объекта.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    Task UpdateAsync(TEntity model);
    
    /// <summary>
    /// Удаляет объект.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    Task DeleteAsync(int id);
}