using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

public class Category : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    private int ParentCategoryId { get; set; }
    public virtual Category ParentCategory { get; set; }
    public virtual ICollection<Category> ChildCategories { get; set; }
    //
    public ICollection<AdvtEntity> Advts { get; set; }
}