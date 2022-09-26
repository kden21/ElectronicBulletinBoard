using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Chat;

public class Message : Entity
{
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    //
    public int AuthorId { get; set; }
    public UserEntity Author { get; set; }
    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }
}