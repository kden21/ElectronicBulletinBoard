using ElectronicBoard.Domain.Report;
using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Report;

/// <summary>
/// Конфигурация для UserReportEntity <see cref="UserReportEntity"/>.
/// </summary>
public class UserReportEntityConfiguration : IEntityTypeConfiguration<UserReportEntity>
{
    public void Configure(EntityTypeBuilder<UserReportEntity> builder)
    {
        builder.ToTable("UserReports")
            .HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.HasOne(r => r.Author)
            .WithMany(u => u.AuthorUserReports)
            .HasForeignKey(r => r.AuthorId);
        builder.HasOne(r => r.User)
            .WithMany(u => u.UserReports)
            .HasForeignKey(r => r.UserId);
    }
}