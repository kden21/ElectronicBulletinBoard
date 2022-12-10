using ElectronicBoard.Domain.Report;
using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Report;

public class CategoryReportEntityConfiguration : IEntityTypeConfiguration<CategoryReportEntity>
{
    public void Configure(EntityTypeBuilder<CategoryReportEntity> builder)
    {
        builder.ToTable("CategoriesReport")
            .HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
    }
}