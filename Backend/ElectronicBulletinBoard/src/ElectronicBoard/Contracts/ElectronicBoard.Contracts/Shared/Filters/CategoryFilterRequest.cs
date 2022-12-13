namespace ElectronicBoard.Contracts.Shared.Filters;

/// <summary>
/// Параметр фильтрации категорий.
/// </summary>
public class CategoryFilterRequest : SharedFilterRequest
{
    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public int ParentCategoryId { get; set; }
}