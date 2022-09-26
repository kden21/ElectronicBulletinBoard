using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Chat;

public class Conversation : Entity
{
    //
    public ICollection<ConversationMember> ConversationMembers { get; set; }
    public ICollection<Message> Messages { get; set; }
}