using ElectronicBoard.Contracts.Photo;
using ElectronicBoard.Contracts.Shared.Filters;

namespace ElectronicBoard.AppServices.Photo.Services;

public interface IPhotoService
{
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="photoId">Идентификатор категории.</param>
    /// <returns>Модель представления категории <see cref="PhotoDto"/>.</returns>
    public Task<PhotoDto> GetPhotoById(int photoId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="photoDto">Модель представления категории без Id <see cref="PhotoDto"/></param>
    /// <returns>Модель представления категории <see cref="PhotoDto"/></returns>
    public Task<PhotoDto> CreatePhoto(PhotoDto photoDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию категорий.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция категорий <see cref="PhotoDto"/>.</returns>
    public Task<IEnumerable<PhotoDto>> GetAllPhotos(CancellationToken cancellation);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="photoId">Идентификатор категории.</param>
    public Task DeletePhoto(int photoId, CancellationToken cancellation);

    public Task<IEnumerable<PhotoDto>> GetFilterPhotos(PhotoFilterRequest? filterRequest, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="photoId">Идентификатор категории.</param>
    /// <param name="photoDto">Обновленная модель представления категории.</param>
    public Task UpdatePhoto(int photoId, PhotoDto photoDto, CancellationToken cancellation);
}