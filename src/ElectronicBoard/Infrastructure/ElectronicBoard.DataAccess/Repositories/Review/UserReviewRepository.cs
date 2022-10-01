using ElectronicBoard.AppServices.Repositories.Review;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters.Review;
using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Review;

/// <inheritdoc />
public class UserReviewRepository : IUserReviewRepository
{
    private readonly IRepository<UserReviewEntity> _repository;

    public UserReviewRepository(IRepository<UserReviewEntity> repository)
    {
        _repository = repository;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<UserReviewEntity>> GetAllUserReviewEntities(UserReviewFilterRequest? userReviewFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(userReviewFilter.Count).Skip(userReviewFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<UserReviewEntity?> GetUserReviewEntityById(int userReviewId)
    {
        return await _repository.GetEntityById(userReviewId);
    }

    /// <inheritdoc />
    public async Task<int> AddUserReviewEntity(UserReviewEntity userReviewModel)
    {
        await _repository.AddEntity(userReviewModel);
        return userReviewModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateUserReviewEntity(UserReviewEntity userReviewModel)
    {
        await _repository.UpdateEntity(userReviewModel);
    }

    /// <inheritdoc />
    public async Task DeleteUserReviewEntity(int advtReviewId)
    {
        await _repository.DeleteEntity(advtReviewId);
    }
}