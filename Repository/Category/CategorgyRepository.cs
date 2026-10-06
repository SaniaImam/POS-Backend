using Microsoft.Data.SqlClient;
using POS.DTOs.ResponseDTOs.Category;

namespace POS.Repository.Category;

public class CategoryRepository : ICategoryRepository
{
    private readonly DatabaseHelper _databaseHelper;

    public CategoryRepository(DatabaseHelper databaseHelper)
    {
        _databaseHelper = databaseHelper;
    }

    public async Task<List<GetCategoryResponse>> GetCategoriesAsync()
    {
        using SqlConnection connection =
            await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command =
            new SqlCommand("sp_GetCategories", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;

        using SqlDataReader reader =
            await command.ExecuteReaderAsync();

        List<GetCategoryResponse> categories = new();

        while (await reader.ReadAsync())
        {
            categories.Add(new GetCategoryResponse
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                CategoryName = reader["CategoryName"]?.ToString()
            });
        }

        return categories;
    }
}