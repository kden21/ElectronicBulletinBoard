using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Repositories.Review;

/// <summary>
/// Репозиторий для работы с отзывами на объявления <see cref="AdvtReviewEntity"/>>
/// </summary>
public interface IAdvtReviewRepository
{
    /// <summary>
    /// Возвращает полный список отзывов.
    /// </summary>
    /// <returns>Коллекция отзывов <see cref="AdvtReviewEntity"/>.</returns>
    public Task<IEnumerable<AdvtReviewEntity>> GetAllAdvtReviewEntities(AdvtReviewFilterRequest? advtReviewFilter, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает отзыв по идентификатору.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    /// <returns>Отзыв <see cref="AdvtReviewEntity"/>.</returns>
    public Task<AdvtReviewEntity?> GetAdvtReviewEntityById(int advtReviewId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет отзыв.
    /// </summary>
    /// <param name="advtReviewModel">Отзыв <see cref="AdvtReviewEntity"/>.</param>
    /// <returns>Идентификатор отзыва <see cref="AdvtReviewEntity"/>.</returns>
    public Task<int> AddAdvtReviewEntity(AdvtReviewEntity advtReviewModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="advtReviewModel">Отзыв <see cref="AdvtReviewEntity"/>.</param>
    public Task UpdateAdvtReviewEntity(AdvtReviewEntity advtReviewModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва <see cref="AdvtReviewEntity"/>.</param>
    public Task DeleteAdvtReviewEntity(int advtReviewId, CancellationToken cancellation);
}