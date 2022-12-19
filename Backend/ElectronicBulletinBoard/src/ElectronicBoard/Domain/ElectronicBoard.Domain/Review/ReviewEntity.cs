using System.ComponentModel.DataAnnotations;
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
    [Required]
    [StringLength(3000)]
    public string Description { get; set; }
    
    /// <summary>
    /// Рейтинг, оставленный в отзыве.
    /// </summary>
    [Required]
    [Range(0, 5)]
    public int Rating { get; set; }
    
    /// <summary>
    /// Идентификатор автора отзыва.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Автор отзыва.
    /// </summary>
    public UserEntity Author { get; set; }
}