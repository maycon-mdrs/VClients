using AutoMapper;
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
    public async Task<ActionResult<IEnumerable<ClientModel>>> Get()
    {
        return Ok();
    }

    [HttpGet("{id:int}", Name = "GetClient")]
    public async Task<ActionResult<ClientModel>> Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> CreateClient(ClientModel clientModel)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateClient(int id, ClientModel clientModel)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteClient(int id)
    {
        return Ok();
    }
}