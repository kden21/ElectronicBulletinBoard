using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Фото.
/// </summary>
public class PhotoEntity:Entity
{
    /// <summary>
    /// Фото, представленное в виде массива байтов.
    /// </summary>
    public byte[]? Photo { get; set; }
    
    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public  int? AdvtId { get; set; }
    
    /// <summary>
    /// Объявление.
    /// </summary>
    public AdvtEntity Advt { get; set; }
}