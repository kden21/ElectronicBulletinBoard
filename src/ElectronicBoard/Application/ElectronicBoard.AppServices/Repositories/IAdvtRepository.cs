using System.Linq.Expressions;
using ElectronicBoard.Contracts.Dto.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Repositories;

/// <summary>
/// Репозиторий для работы с объявлением <see cref="AdvtEntity"/>.
/// </summary>
public interface IAdvtRepository
{
    /// <summary>
    /// Возвращает полный список объявлений.
    /// </summary>
    /// <returns>Коллекция объявлений <see cref="AdvtEntity"/>.</returns>
    public IQueryable<AdvtEntity> GetAll();
    
    /// <summary>
    /// Возвращает список объявлений, проходящих фильтрацию.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтра.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtEntity"/>.</returns>
    public IEnumerable<AdvtEntity> GetAllFiltered(AdvtFilterRequest filterRequest);
    
    /// <summary>
    /// Возвращает объявление по идентификатору.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <returns>Объявление <see cref="AdvtEntity"/>.</returns>
    public Task<AdvtEntity> GetByIdAsync(int advtId);

    /// <summary>
    /// Добавляет объявление.
    /// </summary>
    /// <param name="advtModel">Объявление <see cref="AdvtEntity"/>.</param>
    /// <returns>Идентификатор объявления <see cref="AdvtEntity"/>.</returns>
    public Task<int> AddAsync(AdvtEntity advtModel);

    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtModel">Объявление <see cref="AdvtEntity"/>.</param>
    public Task UpdateAsync(AdvtEntity advtModel);

    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления <see cref="AdvtEntity"/>.</param>
    public Task DeleteAsync(int advtId);
}