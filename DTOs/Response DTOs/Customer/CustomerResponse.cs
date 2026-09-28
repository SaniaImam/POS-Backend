namespace POS.DTOs.ResponseDTOs.Customer;

public class GetCustomerResponse
{
    public int Id { get; set; }
    public string? CustomerCode { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}

public class AddCustomerResponse
{
    public int Id { get; set; }
    public string? CustomerCode { get; set; }
}