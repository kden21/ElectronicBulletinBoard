namespace ElectronicBoard.Contracts.Shared.Filters;

/// <summary>
/// Базовый фильтр.
/// </summary>
public class SharedFilterRequest 
{
    /// <summary>
    /// Количество отображаемых объектов на странице(параметр для пагинации).
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Смещение(параметр для пагинации).
    /// </summary>
    public int Offset { get; set; }
}