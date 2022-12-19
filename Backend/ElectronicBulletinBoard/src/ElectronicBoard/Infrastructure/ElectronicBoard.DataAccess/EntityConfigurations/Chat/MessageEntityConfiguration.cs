using ElectronicBoard.Domain.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicBoard.DataAccess.EntityConfigurations.Chat;

/// <summary>
/// Конфигурация для MessageEntity <see cref="MessageEntity"/>.
/// </summary>
public class MessageEntityConfiguration: IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.ToTable("Messages")
            .HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
    }
}