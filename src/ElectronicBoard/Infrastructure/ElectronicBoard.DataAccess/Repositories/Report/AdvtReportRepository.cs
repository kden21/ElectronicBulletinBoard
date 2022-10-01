using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;
using ElectronicBoard.Domain.Review;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Report;

/// <inheritdoc />
public class AdvtReportRepository : IAdvtReportRepository
{
    private readonly IRepository<AdvtReportEntity> _repository;

    public AdvtReportRepository(IRepository<AdvtReportEntity> repository)
    {
        _repository = repository;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReportEntity>> GetAllAdvtReportEntities(AdvtReportFilterRequest? advtReportFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(advtReportFilter.Count).Skip(advtReportFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<AdvtReportEntity?> GetAdvtReportEntityById(int advtReportId)
    {
        return await _repository.GetEntityById(advtReportId);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtReportEntity(AdvtReportEntity advtReportModel)
    {
        await _repository.AddEntity(advtReportModel);
        return advtReportModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReportEntity(AdvtReportEntity advtReportModel)
    {
        await _repository.UpdateEntity(advtReportModel);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReportEntity(int advtReportId)
    {
        await _repository.DeleteEntity(advtReportId);
    }
}