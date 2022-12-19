using System.Collections.Immutable;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Domain.Chat;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.AppServices.Chat.Conversation.Repositories;

public class ConversationRepository: IConversationRepository
{
    
    private readonly IRepository<ConversationEntity> _repository;

    public ConversationRepository(IRepository<ConversationEntity> repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateConversation(CancellationToken cancellation)
    {
        return await _repository.AddEntity(new ConversationEntity(), cancellation);
    }
    
    public async Task<ConversationEntity?> GetConversationIdByUserIds(int[] userIds,CancellationToken cancellationToken)
    {
        //var query = _repository.Where(c => c.ConversationMembers.Select(cm => cm.Id);

        /*var query = _repository.GetAllEntities();
        var query1 = query.Include(x => x.ConversationMembers);
        var query2 = query1.Where(c => c.ConversationMembers.Count ==usersId.Length);
        var query3 = query2.Where(c => c.ConversationMembers
                .All(x=>usersId.Contains(x.UserId)));

        var query4 = query3.FirstOrDefaultAsync(cancellationToken);
        */


        return await _repository.GetAllEntities()
            .Include(x => x.ConversationMembers)
            .Where(c => c.ConversationMembers.Count == userIds.Length && c.ConversationMembers
                .All(x => userIds.Contains(x.UserId)))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<ConversationEntity>?> GetConversationIds(int userId, CancellationToken cancellationToken)
    {
        var query = await _repository.GetAllEntities()
            .Include(c => c.ConversationMembers)
            .Where(c => c.ConversationMembers
                .Any(x => x.UserId == userId)).Select(x=>x.Id)
            .ToListAsync(cancellationToken);

        return await _repository.GetAllEntities()
            .Include(x=>x.ConversationMembers
            .Where(x=>x.UserId!=userId))
            .Where(x => query.Contains(x.Id)).ToListAsync(cancellationToken);
    }
}