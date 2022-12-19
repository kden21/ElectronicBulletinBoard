using System.ComponentModel.DataAnnotations;

namespace ElectronicBoard.Domain.Report;

/// <summary>
/// Жалоба на объявление.
/// </summary>
public class AdvtReportEntity : ReportEntity
{
    /// <summary>
    /// Идентификатор объявления на каторого написана жалоба.
    /// </summary>
    [Required]
    public int AdvtId { get; set; }
    
    /// <summary>
    /// Объявления на которое написана жалоба.
    /// </summary>
    public AdvtEntity Advt { get; set; }
}