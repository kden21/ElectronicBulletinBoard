using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Отзыв.
/// </summary>
public abstract class ReviewEntity : Entity
{
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
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Идентификатор автора отзыва.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Автор отзыва.
    /// </summary>
    public UserEntity Author { get; set; }
}