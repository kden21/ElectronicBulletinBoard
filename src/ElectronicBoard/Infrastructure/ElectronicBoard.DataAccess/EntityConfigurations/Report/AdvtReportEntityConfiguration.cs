using ElectronicBoard.Domain.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Report;

public class AdvtReportEntityConfiguration : IEntityTypeConfiguration<AdvtReportEntity>
{
    public void Configure(EntityTypeBuilder<AdvtReportEntity> builder)
    {
        builder.ToTable("AdvtReports")
            .HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.HasOne(r => r.Author)
            .WithMany(u => u.AuthorAdvtReports)
            .HasForeignKey(r => r.AuthorId);
        builder.HasOne(r => r.Advt)
            .WithMany(u => u.AdvtReports)
            .HasForeignKey(r => r.AdvtId);
    }
}