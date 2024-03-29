using Microsoft.AspNetCore.Mvc;
using VClients.Api.DTOs;
using VClients.Api.Models;
using VClients.Api.Services.Interfaces;

namespace VClients.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        var productsDto = await _clientService.GetClients();
        if (productsDto == null)
            return NotFound("Products not found");

        return Ok(productsDto);
    }

    [HttpGet("{id:int}", Name = "GetClient")]
    public async Task<ActionResult<ClientDto>> Get(int id)
    {
        var clientDto = await _clientService.GetClientById(id);
        if (clientDto == null)
            return NotFound($"Client with id {id} not found");

        return Ok(clientDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ClientDto clientDto)
    {
        if (clientDto == null)
            return BadRequest("Invalid Data");
            
        await _clientService.CreateClient(clientDto);
        return new CreatedAtRouteResult("GetClient", new { id = clientDto.Id }, clientDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateClient(int id, ClientDto clientDto)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteClient(int id)
    {
        return Ok();
    }
}