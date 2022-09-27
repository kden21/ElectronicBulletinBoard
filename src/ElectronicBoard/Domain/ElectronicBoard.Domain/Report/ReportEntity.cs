using ElectronicBoard.Contracts.Enums;
using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Report;

/// <summary>
/// Жалоба.
/// </summary>
public abstract class ReportEntity : Entity
{
    
    public string Name { get; set; }
    
    /// <summary>
    /// Содержание жалобы.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Дата создания жалобы.
    /// </summary>
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Статус проверки жалобы администратором.
    /// </summary>
    public StatusCheckReport StatusCheck { get; set; }
    
    /// <summary>
    /// Идентификатор автора жалобы.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Автор жалобы.
    /// </summary>
    public UserEntity Author { get; set; }
}