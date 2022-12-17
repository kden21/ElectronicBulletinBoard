using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

/// <summary>
/// Конфигурация для AdvtEntity <see cref="AdvtEntity"/>.
/// </summary>
public class AdvtEntityConfiguration : IEntityTypeConfiguration<Domain.AdvtEntity>
{
    public void Configure(EntityTypeBuilder<Domain.AdvtEntity> builder)
    {
        builder.ToTable("Advts")
            .HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.HasOne(advt => advt.Author)
            .WithMany(author => author.Advts)
            .HasForeignKey(advt => advt.AuthorId);
    }
}