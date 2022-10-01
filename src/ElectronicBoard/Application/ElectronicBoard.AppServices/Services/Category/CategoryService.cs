using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Services.Category;

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
    public async Task<CategoryDto> GetCategoryById(int categoryId)
    {
        var categoryEntity = await _categoryRepository.GetCategoryEntityById(categoryId);
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    /// <inheritdoc />
    public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
    {
        var categoryEntity = _mapper.Map<CategoryEntity>(categoryDto);
        var id = await _categoryRepository.AddCategoryEntity(categoryEntity);
        categoryDto.Id = id;
        return categoryDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryDto>> GetAllCategories(CategoryFilterRequest? filterRequest)
    {
        return _mapper.Map<IEnumerable<CategoryEntity>, IEnumerable<CategoryDto>>(await _categoryRepository.GetAllCategoryEntities(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteCategory(int categoryId)
    {
        await _categoryRepository.DeleteCategoryEntity(categoryId);
    }

    /// <inheritdoc />
    public async Task UpdateCategory(int categoryId, CategoryDto categoryDto)
    {
        categoryDto.Id = categoryId;
        var category = _mapper.Map<CategoryEntity>(categoryDto);
        await _categoryRepository.UpdateCategoryEntity(category);
    }
}