using ElectronicBoard.Contracts.Review.AdvtReview.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Review.AdvtReview.Services;

/// <summary>
/// Сервис для работы с отзывами на объявления <see cref="AdvtReviewEntity"/>.
/// </summary>
public interface IAdvtReviewService
{
    /// <summary>
    /// Возвращает отзыв по Id.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    /// <returns>Модель представления отзыва <see cref="AdvtReviewDto"/>.</returns>
    public Task<AdvtReviewDto> GetAdvtReviewById(int advtReviewId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет отзыв.
    /// </summary>
    /// <param name="advtReviewDto">Модель представления отзыва без Id <see cref="AdvtReviewDto"/></param>
    /// <returns>Модель представления отзыва <see cref="AdvtReviewDto"/></returns>
    public Task<AdvtReviewDto> CreateAdvtReview(AdvtReviewDto advtReviewDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию отзывов.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция отзывов <see cref="AdvtReviewDto"/>.</returns>
    public Task<IEnumerable<AdvtReviewDto>> GetFilterAdvtReviews(AdvtReviewFilterRequest? filterRequest, CancellationToken cancellation);
    public Task<IEnumerable<AdvtReviewDto>> GetAllAdvtReviews(CancellationToken cancellation);

    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    public Task DeleteAdvtReview(int advtReviewId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    /// <param name="advtReviewDto">Обновленная модель представления отзыва.</param>
    public Task UpdateAdvtReview(int advtReviewId, AdvtReviewDto advtReviewDto, CancellationToken cancellation);
}