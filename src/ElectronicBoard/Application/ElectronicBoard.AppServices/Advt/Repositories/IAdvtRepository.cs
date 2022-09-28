using System.Linq.Expressions;
using ElectronicBoard.Domain;
using ElectronicBoard.Infrastructure.Repository;

namespace ElectronicBoard.AppServices.Advt.Repositories;

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
    /// <param name="predicat">Параметр фильтра.</param>
    /// <returns>Коллекция объявлений <see cref="AdvtEntity"/>.</returns>
    public IQueryable<AdvtEntity> GetAllFiltered(Expression<Func<AdvtEntity, bool>> predicat);
    
    /// <summary>
    /// Возвращает объявление по идентификатору.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <returns>Объявление <see cref="AdvtEntity"/>.</returns>
    public Task<AdvtEntity?> GetByIdAsync(int advtId);

    /// <summary>
    /// Добавляет объявление.
    /// </summary>
    /// <param name="model">Объявление <see cref="AdvtEntity"/>.</param>
    /// <returns>Идентификатор объявления <see cref="AdvtEntity"/>.</returns>
    public Task<int> AddAsync(AdvtEntity advtModel);

    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="model">Объявление <see cref="AdvtEntity"/>.</param>
    public Task UpdateAsync(AdvtEntity advtModel);

    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="model">Объявление <see cref="AdvtEntity"/>.</param>
    public Task DeleteAsync(int advtId);
}
