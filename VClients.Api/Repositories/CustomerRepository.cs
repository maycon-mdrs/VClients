using Microsoft.EntityFrameworkCore;
using VClients.Api.Context;
using VClients.Api.Models;
using VClients.Api.Repositories.Interfaces;

namespace VClients.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{   
    private readonly AppDbContext _context;
    
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _context.Customers.Include(c => c.FullAddress).ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer> Create(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> Update(int id, Customer customer)
    {
        Customer customerById = await GetById(id);
        if (customerById is null)
            throw new Exception($"Customer with id {id} not found in Database");
        
        customerById.FullName = customer.FullName;
        customerById.Email = customer.Email;
        customerById.Phone = customer.Phone;
        customerById.UpdatedAt = customer.UpdatedAt;
        customerById.FullAddress = customer.FullAddress;

        _context.Customers.Update(customerById);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> Delete(int id)
    {
        var customer = await GetById(id);
        
        if (customer is null)
            throw new Exception($"Customer with id {id} not found in Database");
        
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
}