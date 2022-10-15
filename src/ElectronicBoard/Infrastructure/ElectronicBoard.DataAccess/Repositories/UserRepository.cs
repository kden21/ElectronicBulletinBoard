using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
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
    public async Task<IEnumerable<UserEntity>> GetAllUserEntities(UserFilterRequest? userFilter, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().OrderBy(c => c.Id).Take(userFilter.Count)
            .Skip(userFilter.Offset).ToListAsync(cancellation);
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
}