using AutoMapper;
using VClients.Api.DTOs;
using VClients.Api.Models;
using VClients.Api.Repositories.Interfaces;
using VClients.Api.Services.Interfaces;

namespace VClients.Api.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    
    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDto>> GetClients()
    {
        var clientsEntity = await _clientRepository.GetAll();
        return _mapper.Map<IEnumerable<ClientDto>>(clientsEntity);
    }

    public async Task<ClientDto> GetClientById(int id)
    {   
        var clientEntity = await _clientRepository.GetById(id);
        return _mapper.Map<ClientDto>(clientEntity);
    }

    public async Task CreateClient(ClientDto clientDto)
    {
        var clientEntity = _mapper.Map<Client>(clientDto);
        await _clientRepository.Create(clientEntity);
        clientDto.Id = clientEntity.Id;
    }

    /*public Task UpdateClient(int id, ClientDto clientDto)
    {
        
    }

    public Task DeleteClient(int id)
    {
        
    }*/
}