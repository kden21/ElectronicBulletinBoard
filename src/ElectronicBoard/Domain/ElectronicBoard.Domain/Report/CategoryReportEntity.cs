using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Report;

/// <summary>
/// Категория жалобы.
/// </summary>
public class CategoryReportEntity : Entity
{
    /// <summary>
    /// Наименование категории жалобы.
    /// </summary>
    public string Name { get; set; }
    
}