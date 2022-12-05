using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Report.UserReport.Dto;

public class UserReportDto
{
    /// <summary>
    /// Идентификатор жалобы.
    /// </summary>
    /// 
    public int? Id { get; set; }

    /// <summary>
    /// Содержание жалобы.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Дата создания жалобы.
    /// </summary>
    public string? CreateDate { get; set; }
    
    /// <summary>
    /// Статус проверки жалобы администратором.
    /// </summary>
    public StatusCheckReport StatusCheck { get; set; }
    
    /// <summary>
    /// Идентификатор автора жалобы.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя на которого написана жалоба.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Идентификатор категории жалобы.
    /// </summary>
    public int CategoryReportId { get; set; }
}