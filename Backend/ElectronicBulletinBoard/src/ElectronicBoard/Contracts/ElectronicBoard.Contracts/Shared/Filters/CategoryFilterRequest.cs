namespace ElectronicBoard.Contracts.Shared.Filters;

public class CategoryFilterRequest : SharedFilterRequest
{
    public int ParentCategoryId { get; set; }
}