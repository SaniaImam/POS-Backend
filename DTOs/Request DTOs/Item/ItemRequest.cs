namespace POS.DTOs.RequestDTOs.Item;

public class AddItemRequest
{
    public string ItemName { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}

public class UpdateItemRequest
{
    public string ItemName { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}