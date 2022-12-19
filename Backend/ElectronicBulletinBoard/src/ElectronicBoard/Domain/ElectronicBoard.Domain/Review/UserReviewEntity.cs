using System.ComponentModel.DataAnnotations;

namespace ElectronicBoard.Domain.Review;

/// <summary>
/// Отзыв о пользователе.
/// </summary>
public class UserReviewEntity : ReviewEntity
{
    /// <summary>
    /// Идентификатор пользователя о котором написан отзыв.
    /// </summary>
    [Required]
    public int UserId { get; set; }
    
    /// <summary>
    /// Пользователь о котором написан отзыв.
    /// </summary>
    public UserEntity User { get; set; }
}