using ElectronicBoard.Contracts.Shared.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Review.UserReview.Repositories;

/// <summary>
/// Репозиторий для работы с отзывами на пользователей <see cref="UserReviewEntity"/>>
/// </summary>
public interface IUserReviewRepository
{
    /// <summary>
    /// Возвращает фильтрованную коллекцию отзывов.
    /// </summary>
    /// <returns>Коллекция отзывов <see cref="UserReviewEntity"/>.</returns>
    public Task<IEnumerable<UserReviewEntity>> GetFilterUserReviewEntities(UserReviewFilterRequest? userReviewFilter, CancellationToken cancellation);
   
    /// <summary>
    /// Возвращает полную коллекцию отзывов.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция отзывов.</returns>
    public Task<IEnumerable<UserReviewEntity>> GetAllUserReviewEntities(CancellationToken cancellation);

    /// <summary>
    /// Возвращает отзыв по идентификатору.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Отзыв <see cref="UserReviewEntity"/>.</returns>
    public Task<UserReviewEntity?> GetUserReviewEntityById(int userReviewId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет отзыв.
    /// </summary>
    /// <param name="userReviewModel">Отзыв <see cref="UserReviewEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор отзыва <see cref="UserReviewEntity"/>.</returns>
    public Task<int> AddUserReviewEntity(UserReviewEntity userReviewModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="userReviewModel">Отзыв <see cref="UserReviewEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateUserReviewEntity(UserReviewEntity userReviewModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва <see cref="UserReviewEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteUserReviewEntity(int userReviewId, CancellationToken cancellation);
}