using System.ComponentModel.DataAnnotations;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Report;

/// <summary>
/// Жалоба.
/// </summary>
public abstract class ReportEntity : Entity
{
    /// <summary>
    /// Идентификатор категории жалобы.
    /// </summary>
    [Required]
    public int CategoryReportId { get; set; }
    
    /// <summary>
    /// Категория жалобы.
    /// </summary>
    public CategoryReportEntity CategoryReport { get; set; }
    
    /// <summary>
    /// Содержание жалобы.
    /// </summary>
    [Required]
    [StringLength(3000)]
    public string Description { get; set; }
    
    /// <summary>
    /// Статус проверки жалобы администратором.
    /// </summary>
    [Required]
    public StatusCheckReport StatusCheck { get; set; }
    
    /// <summary>
    /// Идентификатор автора жалобы.
    /// </summary>
    [Required]
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Автор жалобы.
    /// </summary>
    public UserEntity Author { get; set; }
}