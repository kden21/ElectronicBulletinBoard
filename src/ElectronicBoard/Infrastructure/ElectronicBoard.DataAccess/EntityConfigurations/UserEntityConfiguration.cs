using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<Domain.UserEntity>
{
    public void Configure(EntityTypeBuilder<Domain.UserEntity> builder)
    {
        builder.ToTable("Users")
            .HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        /*builder.HasMany(u => u.Advts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.Id);
        /*builder.HasOne(u=>u)
        builder.HasOne(r => r.Author)
            .WithMany(u => u.AuthorReviews)
            .HasForeignKey(r => r.AuthorId);*/
    }
}