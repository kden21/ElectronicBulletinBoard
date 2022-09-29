using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.DataAccess.Repositories.Shared;
using ElectronicBoard.Domain;
using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Repository<UserEntity> _repository;

    public UserRepository(Repository<UserEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public IQueryable<UserEntity> GetAll()
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<UserEntity> GetByIdAsync(int userId)
    {
        return await _repository.GetByIdAsync(userId);
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(UserEntity userModel)
    {
        await _repository.AddAsync(userModel);
        return userModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(UserEntity userModel)
    {
        await _repository.UpdateAsync(userModel);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int userId)
    {
        await _repository.DeleteAsync(userId);
    }
}