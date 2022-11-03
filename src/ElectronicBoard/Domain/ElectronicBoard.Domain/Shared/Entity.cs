namespace ElectronicBoard.Domain.Shared;

public class Entity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Дата последнего изменения объекта.
    /// </summary>
    public DateTime ModifyDate { get; set; }
    public DateTime CreateDate { get; set; }
}