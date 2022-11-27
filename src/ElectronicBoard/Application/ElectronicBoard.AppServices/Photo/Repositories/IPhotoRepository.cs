using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Photo.Repositories;

public interface IPhotoRepository
{
    /// <summary>
    /// Возвращает полный список фото. 
    /// </summary>
    /// <returns>Коллекция фото <see cref="PhotoEntity"/>.</returns>
    public Task<IEnumerable<PhotoEntity>> GetFilterPhotoEntities(PhotoFilterRequest? photoFilter, CancellationToken cancellation);
    
    public Task<IEnumerable<PhotoEntity>> GetAllPhotoEntities(CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает фото по идентификатору.
    /// </summary>
    /// <param name="photoId">Идентификатор фото.</param>
    /// <returns>Категория <see cref="PhotoEntity"/>.</returns>
    public Task<PhotoEntity?> GetPhotoEntityById(int photoId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет фото.
    /// </summary>
    /// <param name="photoModel">Фото <see cref="PhotoEntity"/>.</param>
    /// <returns>Идентификатор фото <see cref="PhotoEntity"/>.</returns>
    public Task<int> AddPhotoEntity(PhotoEntity photoModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные фото.
    /// </summary>
    /// <param name="photoModel">Фото <see cref="PhotoEntity"/>.</param>
    public Task UpdatePhotoEntity(PhotoEntity photoModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет фото.
    /// </summary>
    /// <param name="photoId">Идентификатор фото <see cref="PhotoEntity"/>.</param>
    public Task DeletePhotoEntity(int photoId, CancellationToken cancellation);
}