using System.ComponentModel.DataAnnotations;
using ElectronicBoard.Domain.Chat;
using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Член чата.
/// </summary>
public class ConversationMemberEntity : Entity
{
    /// <summary>
    /// Идентификатор члена чата.
    /// </summary>
    [Required]
    public int UserId { get; set; }
    
    /// <summary>
    /// Член чата.
    /// </summary>
    public UserEntity User { get; set; }
    
    /// <summary>
    /// Идентификатор чата.
    /// </summary>
    [Required]
    public int ConversationId { get; set; }
    
    /// <summary>
    /// Чат.
    /// </summary>
    public ConversationEntity Conversation { get; set; }
}