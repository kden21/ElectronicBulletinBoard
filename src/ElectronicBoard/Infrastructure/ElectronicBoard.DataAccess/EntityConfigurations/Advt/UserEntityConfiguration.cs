using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Advt;

public class UserEntityConfiguration : IEntityTypeConfiguration<Domain.UserEntity>
{
    public void Configure(EntityTypeBuilder<Domain.UserEntity> builder)
    {
    }
}