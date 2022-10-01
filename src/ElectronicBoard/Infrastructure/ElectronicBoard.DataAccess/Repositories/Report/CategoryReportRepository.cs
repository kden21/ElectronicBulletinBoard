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
    public async Task<IEnumerable<CategoryReportEntity>> GetAllCategoryReportEntities(CategoryReportFilterRequest? categoryReportFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(categoryReportFilter.Count).Skip(categoryReportFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<CategoryReportEntity?> GetCategoryReportEntityById(int categoryReportId)
    {
        return await _repository.GetEntityById(categoryReportId);
    }

    /// <inheritdoc />
    public async Task<int> AddCategoryReportEntity(CategoryReportEntity categoryReportModel)
    {
        await _repository.AddEntity(categoryReportModel);
        return categoryReportModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateCategoryReportEntity(CategoryReportEntity categoryReportModel)
    {
        await _repository.UpdateEntity(categoryReportModel);
    }

    /// <inheritdoc />
    public async Task DeleteCategoryReportEntity(int categoryReportId)
    {
        await _repository.DeleteEntity(categoryReportId);
    }
}