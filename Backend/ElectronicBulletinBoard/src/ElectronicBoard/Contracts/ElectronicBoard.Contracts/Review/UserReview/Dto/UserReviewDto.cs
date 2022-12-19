namespace ElectronicBoard.Contracts.Review.UserReview.Dto;

/// <summary>
/// Модель представления отзыва о пользователе.
/// </summary>
public class UserReviewDto
{
    /// <summary>
    /// Идентификатор отзыва.
    /// </summary>
    public  int Id { get; set; }
    
    /// <summary>
    /// Содержание отзыва.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Рейтинг, оставленный в отзыве.
    /// </summary>
    public int Rating { get; set; }
    
    /// <summary>
    /// Время создания отзыва.
    /// </summary>
    public string? CreateDate { get; set; }
    
    /// <summary>
    /// Идентификатор автора отзыва.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя о котором написан отзыв.
    /// </summary>
    public int UserId { get; set; }
}