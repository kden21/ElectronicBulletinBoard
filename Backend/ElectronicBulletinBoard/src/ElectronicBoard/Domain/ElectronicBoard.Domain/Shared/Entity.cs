using System.ComponentModel.DataAnnotations;

namespace ElectronicBoard.Domain.Shared;

public class Entity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Required]
    public int Id { get; set; }
    
    /// <summary>
    /// Дата последнего изменения.
    /// </summary>
    [Required]
    public DateTime ModifyDate { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    [Required]
    public DateTime CreateDate { get; set; }
}