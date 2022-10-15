using AutoMapper;
using ElectronicBoard.AppServices.Category.Repositories;
using ElectronicBoard.Contracts.Category.Dto;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Category.Services;

/// <inheritdoc />
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<CategoryDto> GetCategoryById(int categoryId, CancellationToken cancellation)
    {
        var categoryEntity = await _categoryRepository.GetCategoryEntityById(categoryId, cancellation);
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    /// <inheritdoc />
    public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto, CancellationToken cancellation)
    {
        var categoryEntity = _mapper.Map<CategoryEntity>(categoryDto);
        var id = await _categoryRepository.AddCategoryEntity(categoryEntity, cancellation);
        categoryDto.Id = id;
        return categoryDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryDto>> GetAllCategories(CategoryFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<CategoryEntity>, IEnumerable<CategoryDto>>(await _categoryRepository.GetAllCategoryEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteCategory(int categoryId, CancellationToken cancellation)
    {
        await _categoryRepository.DeleteCategoryEntity(categoryId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateCategory(int categoryId, CategoryDto categoryDto, CancellationToken cancellation)
    {
        categoryDto.Id = categoryId;
        var category = _mapper.Map<CategoryEntity>(categoryDto);
        await _categoryRepository.UpdateCategoryEntity(category, cancellation);
    }
}