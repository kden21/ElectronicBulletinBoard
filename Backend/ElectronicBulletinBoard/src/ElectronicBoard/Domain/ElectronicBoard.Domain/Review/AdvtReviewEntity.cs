using System.ComponentModel.DataAnnotations;

namespace ElectronicBoard.Domain.Review;

/// <summary>
/// Отзыв об объявлении.
/// </summary>
public class AdvtReviewEntity : ReviewEntity
{
    /// <summary>
    /// Идентификатор объявления о котором написан отзыв.
    /// </summary>
    [Required]
    public int AdvtId { get; set; }
    
    /// <summary>
    /// Объявление о котором написан отзыв.
    /// </summary>
    public AdvtEntity Advt { get; set; }
}