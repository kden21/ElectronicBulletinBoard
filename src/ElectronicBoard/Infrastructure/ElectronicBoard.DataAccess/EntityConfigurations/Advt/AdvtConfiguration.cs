using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Advt;

public class AdvtConfiguration : IEntityTypeConfiguration<Domain.Advt>
{
    public void Configure(EntityTypeBuilder<Domain.Advt> builder)
    {
        builder.ToTable("Advts");

        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Description).HasMaxLength(1000);
        builder.Property(b => b.AdvtName).HasMaxLength((200));
        
    }
}