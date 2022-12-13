namespace ElectronicBoard.Contracts.Photo;

/// <summary>
/// Модель представления фото.
/// </summary>
public class PhotoDto
{
    /// <summary>
    /// Идентификатор фото.
    /// </summary>
    public int? Id { get; set; }
    
    /// <summary>
    /// Base64 строка.
    /// </summary>
    public string Base64Str { get; set; }
    
    /// <summary>
    /// Идентификатор объявления, которому принадлежит фото.
    /// </summary>
    public int AdvtId { get; set; }
}