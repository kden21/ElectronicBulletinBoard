using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Категория объявления.
/// </summary>
public class CategoryEntity : Entity
{
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
    
    /// <summary>
    /// Родительская категория.
    /// </summary>
    public CategoryEntity? ParentCategory { get; set; }
    
    /// <summary>
    /// Коллекция дочерних категорий.
    /// </summary>
    public ICollection<CategoryEntity>? ChildCategories{ get; set; }
    
    /// <summary>
    /// Коллекция объявлений данной категории.
    /// </summary>
    public ICollection<AdvtEntity>? Advts { get; set; }
}