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
    public async Task<IEnumerable<UserReportEntity>> GetAllUserReportEntities(UserReportFilterRequest? userReportFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(userReportFilter.Count).Skip(userReportFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<UserReportEntity?> GetUserReportEntityById(int userReportId)
    {
        return await _repository.GetEntityById(userReportId);
    }

    /// <inheritdoc />
    public async Task<int> AddUserReportEntity(UserReportEntity userReportModel)
    {
        await _repository.AddEntity(userReportModel);
        return userReportModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateUserReportEntity(UserReportEntity userReportModel)
    {
        await _repository.UpdateEntity(userReportModel);
    }

    /// <inheritdoc />
    public async Task DeleteUserReportEntity(int advtReportId)
    {
        await _repository.DeleteEntity(advtReportId);
    }
}