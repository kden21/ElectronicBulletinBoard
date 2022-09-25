namespace ElectronicBoard.Contracts;

/// <summary>
/// Модель представления объявления.
/// </summary>
public class AdvtDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название объявления.
    /// </summary>
    public string AdvtName { get; set; } 
    
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }
}