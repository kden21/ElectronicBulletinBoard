using ElectronicBoard.AppServices.Category.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

/// <inheritdoc />
public class CategoryRepository : ICategoryRepository
{
    private readonly IRepository<CategoryEntity> _repository;

    public CategoryRepository(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryEntity>> GetFilterCategoryEntities(CategoryFilterRequest? categoryFilter, CancellationToken cancellation)
    {
        var query = _repository.GetAllEntities().OrderBy(c => c.Id);
        return await query
            .Skip(categoryFilter.Offset)
            .Take(categoryFilter.Count==0?query.Count():categoryFilter.Count)
            .ToListAsync(cancellation);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<CategoryEntity>> GetAllCategoryEntities(CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<CategoryEntity?> GetCategoryEntityById(int categoryId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(categoryId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddCategoryEntity(CategoryEntity categoryModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(categoryModel, cancellation);
        return categoryModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateCategoryEntity(CategoryEntity categoryModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(categoryModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteCategoryEntity(int categoryId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(categoryId, cancellation);
    }
}