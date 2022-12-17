using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Review;

/// <summary>
/// Конфигурация для UserReviewEntity <see cref="UserReviewEntity"/>.
/// </summary>
public class UserReviewEntityConfiguration : IEntityTypeConfiguration<UserReviewEntity>
{
    public void Configure(EntityTypeBuilder<UserReviewEntity> builder)
    {
        builder.ToTable("UserReviews")
            .HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.HasOne(r => r.Author)
            .WithMany(u => u.AuthorUserReviews)
            .HasForeignKey(r => r.AuthorId);
        builder.HasOne(r => r.User)
            .WithMany(u => u.UserReviews)
            .HasForeignKey(r => r.UserId);
    }
}
