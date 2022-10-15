using ElectronicBoard.AppServices.Report.AdvtReport.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters.Report;
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
    public async Task<IEnumerable<AdvtReportEntity>> GetAllAdvtReportEntities(AdvtReportFilterRequest? advtReportFilter, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(advtReportFilter.Count)
            .Skip(advtReportFilter.Offset).ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<AdvtReportEntity?> GetAdvtReportEntityById(int advtReportId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(advtReportId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtReportEntity(AdvtReportEntity advtReportModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(advtReportModel, cancellation);
        return advtReportModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReportEntity(AdvtReportEntity advtReportModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(advtReportModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReportEntity(int advtReportId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtReportId, cancellation);
    }
}