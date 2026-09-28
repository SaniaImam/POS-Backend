using POS.DTOs.RequestDTOs.Customer;
using POS.DTOs.ResponseDTOs.Customer;
using POS.Repository.Customer;

namespace POS.Services.Customer;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<GetCustomerResponse>> GetCustomersAsync()
    {
        return await _customerRepository.GetCustomersAsync();
    }

    public async Task<AddCustomerResponse> AddCustomerAsync(
        AddCustomerRequest request)
    {
        return await _customerRepository.AddCustomerAsync(request);
    }

    public async Task<int> UpdateCustomerAsync(
        int id,
        UpdateCustomerRequest request)
    {
        return await _customerRepository.UpdateCustomerAsync(id,request);
    }

    public async Task<int> DeleteCustomerAsync(int id)
    {
        return await _customerRepository.DeleteCustomerAsync(id);
    }
}