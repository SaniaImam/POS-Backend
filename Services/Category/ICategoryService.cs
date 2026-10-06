using POS.DTOs.ResponseDTOs.Category;

namespace POS.Services.Category;

public interface ICategoryService
{
    Task<List<GetCategoryResponse>> GetCategoriesAsync();
}