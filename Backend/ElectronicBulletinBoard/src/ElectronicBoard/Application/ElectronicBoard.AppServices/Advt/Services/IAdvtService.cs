using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Contracts.Advt.UpdateAdvt;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Contracts.Shared.Filters;

namespace ElectronicBoard.AppServices.Advt.Services;

/// <summary>
/// Сервис для работы с объявлениями <see cref="AdvtDto"/>.
/// </summary>
public interface IAdvtService
{
    /// <summary>
    /// Возвращает объявление по Id.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления объявления <see cref="AdvtDto"/>.</returns>
    public Task<AdvtDto> GetAdvtById(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет объявление.
    /// </summary>
    /// <param name="advtDto">Модель представления объявления без Id <see cref="AdvtDto"/></param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления объявления <see cref="AdvtDto"/></returns>
    public Task<AdvtDto> CreateAdvt(AdvtDto advtDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную коллекцию объявлений.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtDto"/>.</returns>
    public Task<IEnumerable<AdvtDto>> GetFilterAdvts(AdvtFilterRequest? filterRequest, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает полную коллекцию объявлений.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<IEnumerable<AdvtDto>> GetAllAdvts(CancellationToken cancellation);

    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteAdvt(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Изменяет статус объявления на удаленное.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task SoftDeleteAdvt(int advtId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="advtDto">Обновленная модель представления объявления.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateAdvt(int advtId, UpdateAdvtRequest model, CancellationToken cancellation);
    
    /// <summary>
    /// Добавляет/удаляет объявление в/из списка избранных объявлений пользователя.
    /// </summary>
    /// <param name="advtId">Идентификатор оюъявления.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="status">Статус действия: удалить, добавить.</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task AdvtInFavorite(int advtId, int userId, StatusAction status, CancellationToken cancellation);
}