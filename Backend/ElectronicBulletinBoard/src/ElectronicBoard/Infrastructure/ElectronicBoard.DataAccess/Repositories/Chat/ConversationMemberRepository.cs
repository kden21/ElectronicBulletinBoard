using ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Chat;

/// <inheritdoc />
public class ConversationMemberRepository: IConversationMemberRepository
{
    private readonly IRepository<ConversationMemberEntity> _repository;

    public ConversationMemberRepository(IRepository<ConversationMemberEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<int>?> GetMemberById(int userId, CancellationToken cancellationToken)
    {
        return await _repository.Where(cm => cm.UserId == userId).Select(cm=>cm.ConversationId).ToListAsync(cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task CreateMemberEntity(int userId, int conversationId, CancellationToken cancellationToken)
    {
        await _repository.AddEntity(new ConversationMemberEntity()
        {
            UserId = userId,
            ConversationId = conversationId
        }, cancellationToken);
    }
}