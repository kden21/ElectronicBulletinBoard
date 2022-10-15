namespace ElectronicBoard.Contracts.Review.UserReview.Dto;

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
    public double? Rating { get; set; }
    
    /// <summary>
    /// Время создания отзыва.
    /// </summary>
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Идентификатор автора отзыва.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя о котором написан отзыв.
    /// </summary>
    public int UserId { get; set; }
}