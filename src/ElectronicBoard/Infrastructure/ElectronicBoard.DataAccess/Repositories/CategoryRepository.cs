using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters;
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
    public async Task<IEnumerable<CategoryEntity>> GetAllCategoryEntities(CategoryFilterRequest? categoryFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(categoryFilter.Count).Skip(categoryFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<CategoryEntity?> GetCategoryEntityById(int categoryId)
    {
        return await _repository.GetEntityById(categoryId);
    }

    /// <inheritdoc />
    public async Task<int> AddCategoryEntity(CategoryEntity categoryModel)
    {
        await _repository.AddEntity(categoryModel);
        return categoryModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateCategoryEntity(CategoryEntity categoryModel)
    {
        await _repository.UpdateEntity(categoryModel);
    }

    /// <inheritdoc />
    public async Task DeleteCategoryEntity(int categoryId)
    {
        await _repository.DeleteEntity(categoryId);
    }
}