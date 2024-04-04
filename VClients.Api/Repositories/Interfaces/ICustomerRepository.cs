using VClients.Api.Models;

namespace VClients.Api.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer?> GetById(int id);
    Task<Customer> Create(Customer customer);
    Task<Customer> Update(int id, Customer customer);
    Task<Customer> Delete(int id);
}