using ElectronicBoard.AppServices.Review.UserReview.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters.Review;
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
    public async Task<IEnumerable<UserReviewEntity>> GetFilterUserReviewEntities(UserReviewFilterRequest? userReviewFilter, CancellationToken cancellation)
    {
        var query = _repository.GetAllEntities().OrderBy(c => c.Id);
        return await query.Where(ur => ur.UserId == userReviewFilter.UserReviewId).ToListAsync();
        /*.Skip(userReviewFilter.Offset)
        .Take(userReviewFilter.Count==0?query.Count():userReviewFilter.Count)
        .ToListAsync(cancellation);*/
    }
    
    
    /// <inheritdoc />
    public async Task<IEnumerable<UserReviewEntity>> GetAllUserReviewEntities(CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<UserReviewEntity?> GetUserReviewEntityById(int userReviewId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(userReviewId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddUserReviewEntity(UserReviewEntity userReviewModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(userReviewModel, cancellation);
        return userReviewModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateUserReviewEntity(UserReviewEntity userReviewModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(userReviewModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteUserReviewEntity(int advtReviewId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtReviewId, cancellation);
    }
}