using ElectronicBoard.Contracts.Chat.ConversationMember;

namespace ElectronicBoard.Contracts.Chat.Conversation;

public class ConversationDto
{
    public int Id { get; set; }
    /// <summary>
    /// Коллекция членов чата.
    /// </summary>
    public ICollection<ConversationMemberDto> ConversationMembers { get; set; }
    
    /*/// <summary>
    /// Коллекция сообщений.
    /// </summary>
    public ICollection<MessageEntity> Messages { get; set; }*/

}