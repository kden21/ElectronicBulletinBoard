using ElectronicBoard.Contracts.User.Dto;

namespace ElectronicBoard.Contracts.Chat.ConversationMember;

public class ConversationMemberDto
{
    public int Id { get; set; }
    /// <summary>
    /// Идентификатор члена чата.
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// Идентификатор чата.
    /// </summary>
    public int ConversationId { get; set; }
}