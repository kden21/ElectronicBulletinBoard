using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Report;

/// <inheritdoc />
public class CategoryReportRepository : ICategoryReportRepository
{
    private readonly IRepository<CategoryReportEntity> _repository;

    public CategoryReportRepository(IRepository<CategoryReportEntity> repository)
    {
        _repository = repository;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<CategoryReportEntity>> GetAllCategoryReportEntities(CategoryReportFilterRequest? categoryReportFilter, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(categoryReportFilter.Count)
            .Skip(categoryReportFilter.Offset).ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<CategoryReportEntity?> GetCategoryReportEntityById(int categoryReportId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(categoryReportId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddCategoryReportEntity(CategoryReportEntity categoryReportModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(categoryReportModel, cancellation);
        return categoryReportModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateCategoryReportEntity(CategoryReportEntity categoryReportModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(categoryReportModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteCategoryReportEntity(int categoryReportId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(categoryReportId, cancellation);
    }
}