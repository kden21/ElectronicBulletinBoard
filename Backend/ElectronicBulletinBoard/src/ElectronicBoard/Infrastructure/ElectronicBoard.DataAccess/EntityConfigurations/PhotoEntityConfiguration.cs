using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

/// <summary>
/// Конфигурация для PhotoEntity <see cref="PhotoEntity"/>.
/// </summary>
public class PhotoEntityConfiguration: IEntityTypeConfiguration<Domain.PhotoEntity>
{
    public void Configure(EntityTypeBuilder<Domain.PhotoEntity> builder)
    {
        builder.ToTable("Photos")
            .HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
    }
}