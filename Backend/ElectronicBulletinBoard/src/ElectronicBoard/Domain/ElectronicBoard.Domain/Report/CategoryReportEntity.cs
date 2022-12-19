using System.ComponentModel.DataAnnotations;
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
    [Required]
    [StringLength(64)]
    public string Name { get; set; }

}