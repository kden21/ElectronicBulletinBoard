namespace ElectronicBoard.Domain.Shared;

public class Entity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Дата последнего изменения.
    /// </summary>
    public DateTime ModifyDate { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreateDate { get; set; }
}