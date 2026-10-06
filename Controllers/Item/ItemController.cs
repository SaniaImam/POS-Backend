using Microsoft.AspNetCore.Mvc;
using POS.DTOs.RequestDTOs.Item;
using POS.Services.Item;

namespace POS.Controllers.Item;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("GetItems")]
    public async Task<IActionResult> GetItems()
    {
        var items = await _itemService.GetItemsAsync();

        return Ok(items);
    }

    [HttpPost("AddItem")]
    public async Task<IActionResult> AddItem(AddItemRequest request)
    {
        var item = await _itemService.AddItemAsync(request);

        return Ok(item);
    }

    [HttpPost("UpdateItem/{id}")]
    public async Task<IActionResult> UpdateItem(int id, UpdateItemRequest request)
    {
        await _itemService.UpdateItemAsync(id, request);

        return Ok();
    }

    [HttpPost("DeleteItem/{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        await _itemService.DeleteItemAsync(id);

        return Ok();
    }
}