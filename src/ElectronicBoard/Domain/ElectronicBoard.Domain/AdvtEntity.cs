using ElectronicBoard.Contracts.Enums;
using ElectronicBoard.Domain.Report;
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
    public string Description { get; set; }
    
    /// <summary>
    /// Фото профиля.
    /// </summary>
    public string Photo { get; set; }
    
    /// <summary>
    /// Статус актуальности объявления.
    /// </summary>
    public StatusAdvt Status { get; set; }
    
    //public int CategoryId { get; set; }
    //public Category Category { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public UserEntity User { get; set; }
    //public ICollection<AdvtReport> AdvtReports { get; set; }
   // public ICollection<AdvtReview> AdvtReviews { get; set; }
}