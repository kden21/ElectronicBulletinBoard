using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Объявление.
/// </summary>
public class Advt : Entity
{
    /// <summary>
    /// Наименование.
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