namespace ElectronicBoard.Contracts.Dto;

/// <summary>
/// Модель представления категории объявления.
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование категории.
    /// </summary>
    public string Name { get; set; }
}