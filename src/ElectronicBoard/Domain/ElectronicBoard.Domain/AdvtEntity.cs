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
    public string Name { get; set; } 
    
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Фото профиля.
    /// </summary>
    public byte[]? Photo { get; set; }
    
    /// <summary>
    /// Статус актуальности объявления.
    /// </summary>
    public StatusAdvt Status { get; set; }
    
    public  string Location { get; set; }
    
    /// <summary>
    /// Идентификатор категории объявления.
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Категория объявления.
    /// </summary>
    public CategoryEntity Category { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя-владельца объявления.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Пользователь-владелец объявления.
    /// </summary>
    public UserEntity User { get; set; }
    
    /// <summary>
    /// Коллекция жалоб на объявление.
    /// </summary>
    public ICollection<AdvtReportEntity>? AdvtReports { get; set; }
    
    /// <summary>
    /// Коллекция отзывов об объявлении.
    /// </summary>
    public ICollection<AdvtReviewEntity>? AdvtReviews { get; set; }
    
}