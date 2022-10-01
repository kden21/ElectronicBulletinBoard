using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;

namespace ElectronicBoard.AppServices.Repositories.Review;

/// <summary>
/// Репозиторий для работы с отзывами на пользователей <see cref="UserReviewEntity"/>>
/// </summary>
public interface IUserReviewRepository
{
    /// <summary>
    /// Возвращает полный список отзывов.
    /// </summary>
    /// <returns>Коллекция отзывов <see cref="UserReviewEntity"/>.</returns>
    public Task<IEnumerable<UserReviewEntity>> GetAllUserReviewEntities(UserReviewFilterRequest? userReviewFilter);
    
    /// <summary>
    /// Возвращает отзыв по идентификатору.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    /// <returns>Отзыв <see cref="UserReviewEntity"/>.</returns>
    public Task<UserReviewEntity?> GetUserReviewEntityById(int userReviewId);

    /// <summary>
    /// Добавляет отзыв.
    /// </summary>
    /// <param name="userReviewModel">Отзыв <see cref="UserReviewEntity"/>.</param>
    /// <returns>Идентификатор отзыва <see cref="UserReviewEntity"/>.</returns>
    public Task<int> AddUserReviewEntity(UserReviewEntity userReviewModel);

    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="userReviewModel">Отзыв <see cref="UserReviewEntity"/>.</param>
    public Task UpdateUserReviewEntity(UserReviewEntity userReviewModel);

    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва <see cref="UserReviewEntity"/>.</param>
    public Task DeleteUserReviewEntity(int userReviewId);
}