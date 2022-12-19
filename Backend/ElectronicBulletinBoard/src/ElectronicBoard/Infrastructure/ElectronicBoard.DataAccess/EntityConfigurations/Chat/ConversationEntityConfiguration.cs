using ElectronicBoard.Domain.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Chat;

/// <summary>
/// Конфигурация для ConversationEntity <see cref="ConversationEntity"/>.
/// </summary>
public class ConversationEntityConfiguration: IEntityTypeConfiguration<ConversationEntity>
{
    public void Configure(EntityTypeBuilder<ConversationEntity> builder)
    {
        builder.ToTable("Conversations")
            .HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
    }
}