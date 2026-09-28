namespace POS.DTOs.RequestDTOs.Customer;

public class AddCustomerRequest
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}

public class UpdateCustomerRequest
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}