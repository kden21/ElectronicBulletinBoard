using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

public class PhotoEntityConfiguration: IEntityTypeConfiguration<Domain.PhotoEntity>
{
    public void Configure(EntityTypeBuilder<Domain.PhotoEntity> builder)
    {
        builder.ToTable("Photos")
            .HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
    }
}