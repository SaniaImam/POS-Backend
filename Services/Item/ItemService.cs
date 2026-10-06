using POS.DTOs.RequestDTOs.Item;
using POS.DTOs.ResponseDTOs.Item;
using POS.Repository.Item;

namespace POS.Services.Item;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<List<GetItemResponse>> GetItemsAsync()
    {
        return await _itemRepository.GetItemsAsync();
    }

    public async Task<AddItemResponse> AddItemAsync(AddItemRequest request)
    {
        return await _itemRepository.AddItemAsync(request);
    }

    public async Task UpdateItemAsync(int id, UpdateItemRequest request)
    {
        await _itemRepository.UpdateItemAsync(id, request);
    }

    public async Task DeleteItemAsync(int id)
    {
        await _itemRepository.DeleteItemAsync(id);
    }
}