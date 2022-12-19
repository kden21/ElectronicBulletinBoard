using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

/// <summary>
/// Конфигурация для UserEntity <see cref="UserEntity"/>.
/// </summary>
public class UserEntityConfiguration : IEntityTypeConfiguration<Domain.UserEntity>
{
    public void Configure(EntityTypeBuilder<Domain.UserEntity> builder)
    {
        builder.ToTable("Users")
            .HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
    }
}