using POS.DTOs.RequestDTOs.Item;
using POS.DTOs.ResponseDTOs.Item;

namespace POS.Services.Item;

public interface IItemService
{
    Task<List<GetItemResponse>> GetItemsAsync();

    Task<AddItemResponse> AddItemAsync(AddItemRequest request);

    Task UpdateItemAsync(int id, UpdateItemRequest request);

    Task DeleteItemAsync(int id);
}