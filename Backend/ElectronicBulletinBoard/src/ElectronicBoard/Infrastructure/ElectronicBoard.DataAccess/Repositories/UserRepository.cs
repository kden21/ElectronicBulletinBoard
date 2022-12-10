using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using ElectronicBoard.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

/// <inheritdoc />
public class UserRepository : IUserRepository
{
    private readonly IRepository<UserEntity> _repository;

    public UserRepository(IRepository<UserEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<UserEntity>> GetAllUserEntities(CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().ToListAsync(cancellation);
    }
    
    public async Task<IEnumerable<UserEntity>> GetFilterUserEntities(UserFilterRequest? userFilter, CancellationToken cancellation)
    {
        IQueryable<UserEntity> query;
        if (userFilter.AdvtFavoriteId.HasValue)
        { 
            query = _repository.GetAllEntities().Include(u=>u.FavoriteAdvts).OrderBy(c => c.Id);
            query=query.Where(u=>u.FavoriteAdvts.FirstOrDefault(a=>a.Id==userFilter.AdvtFavoriteId).Id==userFilter.AdvtFavoriteId);
        }
        else
        {
            query = _repository.GetAllEntities().OrderBy(c => c.Id);
        }
        
        if (userFilter.StatusUser != null)
            query = (IOrderedQueryable<UserEntity>) query.Where(u => u.StatusUser == userFilter!.StatusUser);
        return await query.ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<UserEntity?> GetUserEntityById(int userId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(userId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddUserEntity(UserEntity userModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(userModel, cancellation);
        return userModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateUserEntity(UserEntity userModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(userModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteUserEntity(int userId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(userId, cancellation);
    }
    
    /// <inheritdoc />
    public async Task SoftDeleteUserEntity(int userId, CancellationToken cancellation)
    {
        
        var user = await _repository.GetEntityById(userId, cancellation);
        user.StatusUser = StatusUser.Archive;
        await _repository.UpdateEntity(user, cancellation);
    }

    public async Task<UserEntity> GetUserEntityByAccountId(int accountId, CancellationToken cancellation)
    {
        try
        {
            return await _repository.Where(u => u.AccountId == accountId).FirstOrDefaultAsync(cancellation);
        }
        catch
        {
            throw new EntityNotFoundException("Пользователь не найден");
        }
    }
}