using POS.DTOs.ResponseDTOs.Category;

namespace POS.Repository.Category;

public interface ICategoryRepository
{
    Task<List<GetCategoryResponse>> GetCategoriesAsync();
}
