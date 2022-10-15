using ElectronicBoard.Contracts.Review.UserReview.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Review.UserReview.Services;

/// <summary>
/// Сервис для работы с отзывами на объявления <see cref="UserReviewEntity"/>.
/// </summary>
public interface IUserReviewService
{
    /// <summary>
    /// Возвращает отзыв по Id.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    /// <returns>Модель представления отзыва <see cref="UserReviewDto"/>.</returns>
    public Task<UserReviewDto> GetUserReviewById(int userReviewId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет отзыв.
    /// </summary>
    /// <param name="userReviewDto">Модель представления отзыва без Id <see cref="UserReviewDto"/></param>
    /// <returns>Модель представления отзыва <see cref="UserReviewDto"/></returns>
    public Task<UserReviewDto> CreateUserReview(UserReviewDto userReviewDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию отзывов.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция отзывов <see cref="UserReviewDto"/>.</returns>
    public Task<IEnumerable<UserReviewDto>> GetAllUserReviews(UserReviewFilterRequest? filterRequest, CancellationToken cancellation);

    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    public Task DeleteUserReview(int userReviewId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    /// <param name="userReviewDto">Обновленная модель представления отзыва.</param>
    public Task UpdateUserReview(int userReviewId, UserReviewDto userReviewDto, CancellationToken cancellation);
}