using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

/// <summary>
/// Конфигурация для CategoryEntity <see cref="CategoryEntity"/>.
/// </summary>
public class CategoryEntityConfiguration : IEntityTypeConfiguration<Domain.CategoryEntity>
{
    public void Configure(EntityTypeBuilder<Domain.CategoryEntity> builder)
    {
        builder.ToTable("Categories")
            .HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.ChildCategories)
            .HasForeignKey(c=>c.ParentCategoryId);
    }
}