namespace ElectronicBoard.Contracts.Shared.Filters;

/// <summary>
/// Модель фильра объявления.
/// </summary>
public class AdvtFilterRequest : SharedFilterRequest
{
    public string? Name {get; set;}
    public string? Location {get; set;}
    public string? Description {get; set;}
    public int? CategoryId { get; set; }
    public int? UserId { get; set; }
}