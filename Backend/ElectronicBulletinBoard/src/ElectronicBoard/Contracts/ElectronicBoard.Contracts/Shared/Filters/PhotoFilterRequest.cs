namespace ElectronicBoard.Contracts.Shared.Filters;

/// <summary>
/// Параметр фильтрации фото.
/// </summary>
public class PhotoFilterRequest:SharedFilterRequest
{
    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public int AdvtId { get; set; }
}