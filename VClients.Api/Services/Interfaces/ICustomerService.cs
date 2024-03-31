using VClients.Api.DTOs;

namespace VClients.Api.Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDTO>> GetCustomers();
    Task<CustomerDTO> GetCustomerById(int id);
    Task CreateCustomer(CustomerRequestDTO customerDto);
    Task UpdateCustomer(int id, CustomerRequestDTO customerDto);
    Task DeleteCustomer(int id);
}