using ElectronicBoard.Domain.Chat;
using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

public class ConversationMember : Entity
{
    //
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }
}