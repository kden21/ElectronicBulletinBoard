namespace ElectronicBoard.Contracts.Review.AdvtReview.Dto;

public class AdvtReviewDto
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
    /// Идентификатор объявления о котором написан отзыв.
    /// </summary>
    public int AdvtId { get; set; }
}