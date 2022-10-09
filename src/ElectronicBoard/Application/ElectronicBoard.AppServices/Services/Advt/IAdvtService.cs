using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;

namespace ElectronicBoard.AppServices.Services.Advt;

/// <summary>
/// Сервис для работы с объявлениями <see cref="AdvtDto"/>.
/// </summary>
public interface IAdvtService
{
    /// <summary>
    /// Возвращает объявление по Id.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <returns>Модель представления объявления <see cref="AdvtDto"/>.</returns>
    public Task<AdvtDto> GetAdvtById(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет объявление.
    /// </summary>
    /// <param name="advtDto">Модель представления объявления без Id <see cref="AdvtDto"/></param>
    /// <returns>Модель представления объявления <see cref="AdvtDto"/></returns>
    public Task<AdvtDto> CreateAdvt(AdvtDto advtDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию объявлений.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtDto"/>.</returns>
    public Task<IEnumerable<AdvtDto>> GetAllAdvts(AdvtFilterRequest? filterRequest, CancellationToken cancellation);

    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    public Task DeleteAdvt(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="advtDto">Обновленная модель представления объявления.</param>
    public Task UpdateAdvt(int advtId, AdvtDto advtDto, CancellationToken cancellation);
}