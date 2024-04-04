using AutoMapper;
using VClients.Api.DTOs;
using VClients.Api.Models;
using VClients.Api.Repositories.Interfaces;
using VClients.Api.Services.Interfaces;

namespace VClients.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    
    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDTO>> GetCustomers()
    {
        var customerEntity = await _customerRepository.GetAll();
        return _mapper.Map<IEnumerable<CustomerDTO>>(customerEntity);
    }

    public async Task<CustomerDTO> GetCustomerById(int id)
    {   
        var customerEntity = await _customerRepository.GetById(id);
        return _mapper.Map<CustomerDTO>(customerEntity);
    }

    public async Task CreateCustomer(CustomerRequestDTO customerDto)
    {
        customerDto.CreatedAt = DateTime.UtcNow;
        var customerEntity = _mapper.Map<Customer>(customerDto);
        await _customerRepository.Create(customerEntity);
        customerDto.Id = customerEntity.Id;
    }

    public async Task UpdateCustomer(int id, CustomerRequestDTO customerDto)
    {   
        customerDto.UpdatedAt = DateTime.UtcNow;
        var customerEntity = _mapper.Map<Customer>(customerDto);
        await _customerRepository.Update(id, customerEntity);
    }

    public async Task DeleteCustomer(int id)
    {
        var customerEntity = _customerRepository.GetById(id).Result;
        await _customerRepository.Delete(customerEntity.Id);
    }
}