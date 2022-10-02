using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters;
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
    public async Task<IEnumerable<UserEntity>> GetAllUserEntities(UserFilterRequest? userFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c => c.Id).Take(userFilter.Count)
            .Skip(userFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<UserEntity?> GetUserEntityById(int userId)
    {
        return await _repository.GetEntityById(userId);
    }

    /// <inheritdoc />
    public async Task<int> AddUserEntity(UserEntity userModel)
    {
        await _repository.AddEntity(userModel);
        return userModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateUserEntity(UserEntity userModel)
    {
        await _repository.UpdateEntity(userModel);
    }

    /// <inheritdoc />
    public async Task DeleteUserEntity(int userId)
    {
        await _repository.DeleteEntity(userId);
    }
}