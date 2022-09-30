using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IRepository<CategoryEntity> _repository;

    public CategoryRepository(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryEntity>> GetAll(CategoryFilterRequest? categoryFilter)
    {
        return await _repository.GetAll().OrderBy(c=>c.Id).Take(categoryFilter.Count).Skip(categoryFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<CategoryEntity?> GetByIdAsync(int categoryId)
    {
        return await _repository.GetByIdAsync(categoryId);
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(CategoryEntity categoryModel)
    {
        await _repository.AddAsync(categoryModel);
        return categoryModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(CategoryEntity categoryModel)
    {
        await _repository.UpdateAsync(categoryModel);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int categoryId)
    {
        await _repository.DeleteAsync(categoryId);
    }
}