namespace ElectronicBoard.Contracts.Shared.Filters.Review;

/// <summary>
/// Параметр фильтрации отзывов о пользователях.
/// </summary>
public class UserReviewFilterRequest : SharedFilterRequest
{
    /// <summary>
    /// Идентификатор пользователя, о котором написан отзыв.
    /// </summary>
    public int UserReviewId { get; set; }
}