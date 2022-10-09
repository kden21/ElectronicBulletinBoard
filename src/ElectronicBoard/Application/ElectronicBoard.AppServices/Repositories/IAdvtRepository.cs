using System.Linq.Expressions;
using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Repositories;

/// <summary>
/// Репозиторий для работы с объявлениями <see cref="AdvtEntity"/>.
/// </summary>
public interface IAdvtRepository
{
    /// <summary>
    /// Возвращает фильтрованный/полный список объявлений.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтра.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtEntity"/>.</returns>
    public Task<IEnumerable<AdvtEntity>> GetAllAdvtEntities(AdvtFilterRequest? filterRequest, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает объявление по идентификатору.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <returns>Объявление <see cref="AdvtEntity"/>.</returns>
    public Task<AdvtEntity> GetAdvtEntityById(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет объявление.
    /// </summary>
    /// <param name="advtModel">Объявление <see cref="AdvtEntity"/>.</param>
    /// <returns>Идентификатор объявления <see cref="AdvtEntity"/>.</returns>
    public Task<int> AddAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtModel">Объявление <see cref="AdvtEntity"/>.</param>
    public Task UpdateAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления <see cref="AdvtEntity"/>.</param>
    public Task DeleteAdvtEntity(int advtId, CancellationToken cancellation);
}
