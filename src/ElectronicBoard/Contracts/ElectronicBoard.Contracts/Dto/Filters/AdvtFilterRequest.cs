namespace ElectronicBoard.Contracts.Dto.Filters;

/// <summary>
/// Модель фильра объявления.
/// </summary>
public class AdvtFilterRequest : SharedFilterRequest
{
    public int? Id { get; set; }
    public string? Name {get; set;}
    public int? CategoryId { get; set; }
    public int? UserId { get; set; }
}