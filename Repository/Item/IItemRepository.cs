using POS.DTOs.RequestDTOs.Item;
using POS.DTOs.ResponseDTOs.Item;

namespace POS.Repository.Item;

public interface IItemRepository
{
    Task<List<GetItemResponse>> GetItemsAsync();

    Task<AddItemResponse> AddItemAsync(AddItemRequest request);

    Task UpdateItemAsync(int id, UpdateItemRequest request);

    Task DeleteItemAsync(int id);
}