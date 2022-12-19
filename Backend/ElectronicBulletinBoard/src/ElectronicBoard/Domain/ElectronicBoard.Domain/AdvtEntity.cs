using System.ComponentModel.DataAnnotations;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Domain.Report;
using ElectronicBoard.Domain.Review;
using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Объявление.
/// </summary>
public class AdvtEntity : Entity
{
    /// <summary>
    /// Наименование.
    /// </summary>
    [Required]
    [StringLength(64)]
    public string Name { get; set; } 
    
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    [Required]
    [StringLength(5000)]
    public string? Description { get; set; }
    
    /// <summary>
    /// Фото профиля.
    /// </summary>
    public ICollection<PhotoEntity>? Photos { get; set; }
    
    /// <summary>
    /// Статус актуальности объявления.
    /// </summary>
    [Required]
    public StatusAdvt Status { get; set; }
    
    [Required]
    public string Location { get; set; }
    
    /// <summary>
    /// Идентификатор категории объявления.
    /// </summary>
    [Required]
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Категория объявления.
    /// </summary>
    public CategoryEntity Category { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя-владельца объявления.
    /// </summary>
    [Required]
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Пользователь-владелец объявления.
    /// </summary>
    public UserEntity Author { get; set; }

    /// <summary>
    /// Пользователи, у которых данное объявление в списке избранных.
    /// </summary>
    public ICollection<UserEntity> UsersVoters { get; set; }
    
    /// <summary>
    /// Коллекция жалоб на объявление.
    /// </summary>
    public ICollection<AdvtReportEntity>? AdvtReports { get; set; }
    
    /// <summary>
    /// Коллекция отзывов об объявлении.
    /// </summary>
    public ICollection<AdvtReviewEntity>? AdvtReviews { get; set; }
    
}