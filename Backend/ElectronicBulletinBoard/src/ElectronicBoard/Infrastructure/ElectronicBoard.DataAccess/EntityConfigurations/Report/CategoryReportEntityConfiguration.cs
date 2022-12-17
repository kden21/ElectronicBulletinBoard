using ElectronicBoard.Domain.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Report;

/// <summary>
/// Конфигурация для CategoryReportEntity <see cref="CategoryReportEntity"/>.
/// </summary>
public class CategoryReportEntityConfiguration : IEntityTypeConfiguration<CategoryReportEntity>
{
    public void Configure(EntityTypeBuilder<CategoryReportEntity> builder)
    {
        builder.ToTable("CategoriesReport")
            .HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
    }
}