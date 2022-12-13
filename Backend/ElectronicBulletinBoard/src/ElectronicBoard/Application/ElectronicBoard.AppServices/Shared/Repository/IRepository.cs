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
    /// <param name="TEntityId">Идентификатор сущности.</param>
    /// <param name="cancellation"></param>
    /// <returns>Объект TEntity.</returns>
    Task<TEntity> GetEntityById(int TEntityId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет объект.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    /// <param name="cancellation"></param>
    /// <returns>Идентификатор объекта.</returns>
    Task<int> AddEntity(TEntity model, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные объекта.
    /// </summary>
    /// <param name="model">Модель представления объекта.</param>
    /// <param name="cancellation"></param>
    Task UpdateEntity(TEntity model, CancellationToken cancellation);

    /// <summary>
    /// Удаляет объект.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    /// <param name="cancellation"></param>
    Task DeleteEntity(int id, CancellationToken cancellation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
}