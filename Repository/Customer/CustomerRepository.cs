using Microsoft.Data.SqlClient;
using POS.DTOs.RequestDTOs.Customer;
using POS.DTOs.ResponseDTOs.Customer;

namespace POS.Repository.Customer;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseHelper _databaseHelper;

    public CustomerRepository(DatabaseHelper databaseHelper)
    {
        _databaseHelper = databaseHelper;
    }

    public async Task<List<GetCustomerResponse>> GetCustomersAsync()
    {
        using SqlConnection connection =
            await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command =
            new SqlCommand("sp_GetCustomers", connection);

        command.CommandType =
            System.Data.CommandType.StoredProcedure;

        using SqlDataReader reader =
            await command.ExecuteReaderAsync();

        List<GetCustomerResponse> customers = new();

        while (await reader.ReadAsync())
        {
            customers.Add(new GetCustomerResponse
            {
                Id = reader.GetInt32(
                    reader.GetOrdinal("Id")
                ),

                CustomerCode = reader.GetString(
                    reader.GetOrdinal("CustomerCode")
                ),

                Name = reader.GetString(
                    reader.GetOrdinal("Name")
                ),

                Phone = reader.GetString(
                    reader.GetOrdinal("Phone")
                ),

                Email = reader.IsDBNull(
                    reader.GetOrdinal("Email")
                )
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("Email")
                    )
            });
        }

        return customers;
    }

    public async Task<AddCustomerResponse> AddCustomerAsync(
     AddCustomerRequest request)
    {
        using SqlConnection connection =
            await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command =
            new SqlCommand("sp_AddCustomer", connection);

        command.CommandType =
            System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue(
            "@Name",
            request.Name
        );

        command.Parameters.AddWithValue(
            "@Phone",
            request.Phone
        );

        command.Parameters.AddWithValue(
            "@Email",
            request.Email ?? (object)DBNull.Value
        );

        using SqlDataReader reader =
            await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            int id = Convert.ToInt32(reader["Id"]);

            if (id == -1)
            {
                return new AddCustomerResponse
                {
                    Id = -1,
                    CustomerCode = null
                };
            }

            return new AddCustomerResponse
            {
                Id = id,

                CustomerCode = reader.GetString(
                    reader.GetOrdinal("CustomerCode")
                )
            };
        }

        throw new Exception("Customer could not be added.");
    }

    public async Task<int> UpdateCustomerAsync(
        int id,
        UpdateCustomerRequest request
    )
    {
        using SqlConnection connection =
            await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command =
            new SqlCommand("sp_UpdateCustomer", connection);

        command.CommandType =
            System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Name", request.Name);
        command.Parameters.AddWithValue("@Phone", request.Phone);
        command.Parameters.AddWithValue(
            "@Email",
            request.Email ?? (object)DBNull.Value
        );

        return await command.ExecuteNonQueryAsync();
    }

    public async Task<int> DeleteCustomerAsync(int id)
    {
        using SqlConnection connection =
            await _databaseHelper.OpenConnectionAsync();

        using SqlCommand command =
            new SqlCommand("sp_DeleteCustomer", connection);

        command.CommandType =
            System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Id", id);

        return await command.ExecuteNonQueryAsync();
    }
}