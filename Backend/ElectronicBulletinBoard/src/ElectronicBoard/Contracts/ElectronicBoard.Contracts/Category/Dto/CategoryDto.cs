namespace ElectronicBoard.Contracts.Category.Dto;

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
    
    /// <summary>
    /// Описание категории.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Идентификатор родительской катеогрии.
    /// </summary>
    public int? ParentCategoryId { get; set; }
}