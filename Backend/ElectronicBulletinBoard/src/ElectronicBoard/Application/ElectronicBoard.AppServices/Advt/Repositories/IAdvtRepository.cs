using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Advt.Repositories;

/// <summary>
/// Репозиторий для работы с объявлениями <see cref="AdvtEntity"/>.
/// </summary>
public interface IAdvtRepository
{
    /// <summary>
    /// Возвращает фильтрованный список объявлений.
    /// </summary>
    /// <param name="advtFilter">Параметр фильтра.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtEntity"/>.</returns>
    public Task<IEnumerable<AdvtEntity>> GetFilterAdvtEntities(AdvtFilterRequest? advtFilter, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает полный список объявлений.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtEntity"/>.</returns>
    public Task<IEnumerable<AdvtEntity>> GetAllAdvtEntities(CancellationToken cancellation);

    /// <summary>
    /// Возвращает объявление по идентификатору.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Объявление <see cref="AdvtEntity"/>.</returns>
    public Task<AdvtEntity> GetAdvtEntityById(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет объявление.
    /// </summary>
    /// <param name="advtModel">Объявление <see cref="AdvtEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор объявления <see cref="AdvtEntity"/>.</returns>
    public Task<int> AddAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtModel">Объявление <see cref="AdvtEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation);

    /// <summary>
    /// Изменяет статус объвления на удаленное.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления <see cref="AdvtEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task SoftDeleteAdvtEntity(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления <see cref="AdvtEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteAdvtEntity(int advtId, CancellationToken cancellation);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="advtId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<AdvtEntity?> GetAdvtEntityByIdIncludeUserVoters(int advtId, CancellationToken cancellation);
}
