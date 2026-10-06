using Microsoft.Data.SqlClient;
using POS.DTOs.RequestDTOs.Item;
using POS.DTOs.ResponseDTOs.Item;

namespace POS.Repository.Item;

public class ItemRepository : IItemRepository
{
    private readonly DatabaseHelper _databaseHelper;

    public ItemRepository(DatabaseHelper databaseHelper)
    {
        _databaseHelper = databaseHelper;
    }

    public async Task<List<GetItemResponse>> GetItemsAsync()
    {
        using SqlConnection connection = await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command = new SqlCommand("sp_GetItems", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        List<GetItemResponse> items = new();

        while (await reader.ReadAsync())
        {
            items.Add(new GetItemResponse
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ItemCode = reader["ItemCode"]?.ToString(),
                ItemName = reader["ItemName"]?.ToString(),
                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                CategoryName = reader["CategoryName"]?.ToString(),
                Price = reader.GetDecimal(reader.GetOrdinal("Price"))
            });
        }

        return items;
    }

    public async Task<AddItemResponse> AddItemAsync(AddItemRequest request)
    {
        using SqlConnection connection = await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command = new SqlCommand("sp_AddItem", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@ItemName", request.ItemName);
        command.Parameters.AddWithValue("@CategoryId", request.CategoryId);
        command.Parameters.AddWithValue("@Price", request.Price);

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        await reader.ReadAsync();

        return new AddItemResponse
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            ItemCode = reader["ItemCode"]?.ToString()
        };
    }
    public async Task UpdateItemAsync(int id, UpdateItemRequest request)
    {
        using SqlConnection connection = await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command = new SqlCommand("sp_UpdateItem", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@ItemName", request.ItemName);
        command.Parameters.AddWithValue("@CategoryId", request.CategoryId);
        command.Parameters.AddWithValue("@Price", request.Price);

        await command.ExecuteNonQueryAsync();
    }
    public async Task DeleteItemAsync(int id)
    {
        using SqlConnection connection = await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command = new SqlCommand("sp_DeleteItem", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Id", id);

        await command.ExecuteNonQueryAsync();
    }
}
