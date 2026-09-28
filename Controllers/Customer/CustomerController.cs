using Microsoft.AspNetCore.Mvc;
using POS.DTOs.RequestDTOs.Customer;
using POS.Services.Customer;

namespace POS.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(
        ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("GetCustomers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers =
            await _customerService.GetCustomersAsync();

        return Ok(customers);
    }

    [HttpPost("AddCustomer")]
    public async Task<IActionResult> AddCustomer(
    AddCustomerRequest request)
    {
        var customer =
            await _customerService.AddCustomerAsync(request);

        if (customer.Id == -1)
        {
            return BadRequest(new
            {
                message = "A customer with this phone number already exists."
            });
        }

        return Ok(new
        {
            message = "Customer added successfully.",
            id = customer.Id,
            customerCode = customer.CustomerCode
        });
    }

    [HttpPost("UpdateCustomer/{id}")]
    public async Task<IActionResult> UpdateCustomer(
        int id,
        UpdateCustomerRequest request)
    {
        int rowsAffected =
            await _customerService.UpdateCustomerAsync(
                id,
                request
            );

        if (rowsAffected == 0)
        {
            return NotFound("Customer not found.");
        }

        return Ok("Customer updated successfully.");
    }

    [HttpPost("DeleteCustomer/{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        int rowsAffected =
            await _customerService.DeleteCustomerAsync(id);

        if (rowsAffected == 0)
        {
            return NotFound("Customer not found.");
        }

        return Ok("Customer deleted successfully.");
    }
}