using Microsoft.AspNetCore.Mvc;
using VClients.Api.DTOs;
using VClients.Api.Models;
using VClients.Api.Services.Interfaces;

namespace VClients.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
    {
        var customerDto = await _customerService.GetCustomers();
        
        /*
         * !customerDto.Any() will return true if customerDto is empty
         * and false if it contains any element.
         */
        if (!customerDto.Any() || customerDto == null)
            return NotFound("Products not found");

        return Ok(customerDto);
    }

    [HttpGet("{id:int}", Name = "GetCustomer")]
    public async Task<ActionResult<CustomerDTO>?> Get(int id)
    {
        var clientDto = await _customerService.GetCustomerById(id);
        if (clientDto == null)
            return NotFound($"Client with id {id} not found");

        return Ok(clientDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CustomerRequestDTO customerDto)
    {
        if (customerDto == null)
            return BadRequest("Invalid Data");
            
        await _customerService.CreateCustomer(customerDto);
        return new CreatedAtRouteResult("GetCustomer", new { id = customerDto.Id }, customerDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CustomerRequestDTO customerDto)
    {
        if (customerDto == null || id == null)
            return BadRequest("Invalid Data");
        
        customerDto.Id = id;
        
        await _customerService.UpdateCustomer(customerDto.Id, customerDto);
        return Ok(customerDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (id == null)
            return BadRequest();
        
        var customerDto = await _customerService.GetCustomerById(id);
        if (customerDto == null)
            return NotFound($"Client with id {id} not found");
        
        await _customerService.DeleteCustomer(customerDto.Id);
        return Ok(customerDto);
    }
}