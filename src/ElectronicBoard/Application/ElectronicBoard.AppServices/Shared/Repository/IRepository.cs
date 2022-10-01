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
    IQueryable<TEntity> GetAllEntities();
    
    /// <summary>
    /// Возвращает объект по идентификатору.
    /// </summary>
    /// <param name="TEntityId">Идентификатор.</param>
    /// <returns>Объект TEntity.</returns>
    Task<TEntity> GetEntityById(int TEntityId);
    
    /// <summary>
    /// Добавляет объект.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    /// <returns>Идентификатор объекта.</returns>
    Task<int> AddEntity(TEntity model);
    
    /// <summary>
    /// Обновляет данные объекта.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    Task UpdateEntity(TEntity model);
    
    /// <summary>
    /// Удаляет объект.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    Task DeleteEntity(int id);
}