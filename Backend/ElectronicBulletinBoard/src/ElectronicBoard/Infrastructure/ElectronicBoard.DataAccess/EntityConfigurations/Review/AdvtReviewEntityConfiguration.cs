using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Review;

/// <summary>
/// Конфигурация для AdvtReviewEntity <see cref="AdvtReviewEntity"/>.
/// </summary>
public class AdvtReviewEntityConfiguration : IEntityTypeConfiguration<AdvtReviewEntity>
{
    public void Configure(EntityTypeBuilder<AdvtReviewEntity> builder)
    {
        builder.ToTable("AdvtReviews")
            .HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.HasOne(r => r.Author)
            .WithMany(u => u.AuthorAdvtReviews)
            .HasForeignKey(r => r.AuthorId);
        builder.HasOne(r => r.Advt)
            .WithMany(u => u.AdvtReviews)
            .HasForeignKey(r => r.AdvtId);
    }
}