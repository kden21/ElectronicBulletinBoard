using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Advt;

public class AdvtEntityConfiguration : IEntityTypeConfiguration<Domain.AdvtEntity>
{
    public void Configure(EntityTypeBuilder<Domain.AdvtEntity> builder)
    {
    }
}