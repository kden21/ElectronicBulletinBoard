using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Report;

/// <inheritdoc />
public class UserReportRepository : IUserReportRepository
{
    private readonly IRepository<UserReportEntity> _repository;

    public UserReportRepository(IRepository<UserReportEntity> repository)
    {
        _repository = repository;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<UserReportEntity>> GetAllUserReportEntities(UserReportFilterRequest? userReportFilter, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(userReportFilter.Count)
            .Skip(userReportFilter.Offset).ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<UserReportEntity?> GetUserReportEntityById(int userReportId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(userReportId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddUserReportEntity(UserReportEntity userReportModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(userReportModel, cancellation);
        return userReportModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateUserReportEntity(UserReportEntity userReportModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(userReportModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteUserReportEntity(int advtReportId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtReportId, cancellation);
    }
}