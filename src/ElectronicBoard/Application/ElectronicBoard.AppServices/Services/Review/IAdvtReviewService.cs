using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Services.Review;

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
    public Task<AdvtReviewDto> GetAdvtReviewById(int advtReviewId);

    /// <summary>
    /// Добавляет отзыв.
    /// </summary>
    /// <param name="advtReviewDto">Модель представления отзыва без Id <see cref="AdvtReviewDto"/></param>
    /// <returns>Модель представления отзыва <see cref="AdvtReviewDto"/></returns>
    public Task<AdvtReviewDto> CreateAdvtReview(AdvtReviewDto advtReviewDto);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию отзывов.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция отзывов <see cref="AdvtReviewDto"/>.</returns>
    public Task<IEnumerable<AdvtReviewDto>> GetAllAdvtReviews(AdvtReviewFilterRequest? filterRequest);

    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    public Task DeleteAdvtReview(int advtReviewId);

    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    /// <param name="advtReviewDto">Обновленная модель представления отзыва.</param>
    public Task UpdateAdvtReview(int advtReviewId, AdvtReviewDto advtReviewDto);
}