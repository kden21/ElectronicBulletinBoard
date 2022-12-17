using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations;

/// <summary>
/// Конфигурация для ConversationMemberEntity <see cref="ConversationMemberEntity"/>.
/// </summary>
public class ConversationMemberConfiguration: IEntityTypeConfiguration<ConversationMemberEntity>
{
    public void Configure(EntityTypeBuilder<ConversationMemberEntity> builder)
    {
        builder.ToTable("ConversationMembers")
            .HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
    }
}