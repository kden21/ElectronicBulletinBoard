namespace ElectronicBoard.Contracts.Shared.Filters.Review;

/// <summary>
/// Параметр фильтрации отзывов об объявлениях.
/// </summary>
public class AdvtReviewFilterRequest : SharedFilterRequest
{
    /// <summary>
    /// Идентификатор объявляния, о котором написан отзыв.
    /// </summary>
    public int AdvtId { get; set; }
}