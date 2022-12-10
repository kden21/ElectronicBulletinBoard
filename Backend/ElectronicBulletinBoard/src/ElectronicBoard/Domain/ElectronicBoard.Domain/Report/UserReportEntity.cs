namespace ElectronicBoard.Domain.Report;

/// <summary>
/// Жалоба на пользователя.
/// </summary>
public class UserReportEntity : ReportEntity
{
    /// <summary>
    /// Идентификатор пользователя на которого написана жалоба.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Пользователь на которого написана жалоба.
    /// </summary>
    public UserEntity User { get; set; }
}