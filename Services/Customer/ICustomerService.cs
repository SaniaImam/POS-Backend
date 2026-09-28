using POS.DTOs.RequestDTOs.Customer;
using POS.DTOs.ResponseDTOs.Customer;

namespace POS.Services.Customer;

public interface ICustomerService
{
    Task<List<GetCustomerResponse>> GetCustomersAsync();

    Task<AddCustomerResponse> AddCustomerAsync(AddCustomerRequest request);

    Task<int> UpdateCustomerAsync(int id, UpdateCustomerRequest request);

    Task<int> DeleteCustomerAsync(int id);
}