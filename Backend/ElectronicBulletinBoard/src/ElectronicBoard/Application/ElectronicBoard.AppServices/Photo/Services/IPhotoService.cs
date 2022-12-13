using ElectronicBoard.Contracts.Photo;
using ElectronicBoard.Contracts.Shared.Filters;

namespace ElectronicBoard.AppServices.Photo.Services;

/// <summary>
/// Сервис для работы с фотографиями объявлений <see cref="PhotoDto"/>.
/// </summary>
public interface IPhotoService
{
    /// <summary>
    /// Возвращает фото по Id.
    /// </summary>
    /// <param name="photoId">Идентификатор фото.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления фото <see cref="PhotoDto"/>.</returns>
    public Task<PhotoDto> GetPhotoById(int photoId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет фото.
    /// </summary>
    /// <param name="photoDto">Модель представления фото<see cref="PhotoDto"/></param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления фото <see cref="PhotoDto"/></returns>
    public Task<PhotoDto> CreatePhoto(PhotoDto photoDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает полную коллекцию категорий.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция категорий <see cref="PhotoDto"/>.</returns>
    public Task<IEnumerable<PhotoDto>> GetAllPhotos(CancellationToken cancellation);

    /// <summary>
    /// Удаляет фото.
    /// </summary>
    /// <param name="photoId">Идентификатор фото.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeletePhoto(int photoId, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную коллекцию категорий.
    /// </summary>
    /// <param name="filterRequest">Фильтр выборки фото.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<IEnumerable<PhotoDto>> GetFilterPhotos(PhotoFilterRequest? filterRequest, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные фото.
    /// </summary>
    /// <param name="photoId">Идентификатор фото.</param>
    /// <param name="photoDto">Обновленная модель представления фото.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdatePhoto(int photoId, PhotoDto photoDto, CancellationToken cancellation);
}