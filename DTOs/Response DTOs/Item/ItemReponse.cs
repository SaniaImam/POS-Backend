namespace POS.DTOs.ResponseDTOs.Item;

public class GetItemResponse
{
    public int Id { get; set; }
    public string? ItemCode { get; set; }
    public string? ItemName { get; set; }
    public string? CategoryName { get; set; }
    public decimal Price { get; set; }
}

public class AddItemResponse
{
    public int Id { get; set; }
    public string? ItemCode { get; set; }
}