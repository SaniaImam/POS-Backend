using POS.DTOs.ResponseDTOs.Category;
using POS.Repository.Category;

namespace POS.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<GetCategoryResponse>> GetCategoriesAsync()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }
}