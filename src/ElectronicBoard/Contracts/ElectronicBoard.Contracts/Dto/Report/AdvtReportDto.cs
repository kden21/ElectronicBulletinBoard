using ElectronicBoard.Contracts.Enums;

namespace ElectronicBoard.Contracts.Dto.Report;

public class AdvtReportDto
{
    /// <summary>
    /// Идентификатор жалобы.
    /// </summary>
    /// 
    public int Id { get; set; }

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
    /// Идентификатор объявления на каторого написана жалоба.
    /// </summary>
    public int AdvtId { get; set; }
    
    /// <summary>
    /// Идентификатор категории жалобы.
    /// </summary>
    public int CategoryReportId { get; set; }
}