namespace ElectronicBoard.Contracts.Dto.Filters;

/// <summary>
/// Базовый фильтр, параметры для пагинации.
/// </summary>
public class SharedFilterRequest 
{
    /// <summary>
    /// Количество отображаемых объектов на странице.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Смещение.
    /// </summary>
    public int Offset { get; set; }
}