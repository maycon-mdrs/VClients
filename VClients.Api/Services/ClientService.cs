using AutoMapper;
using VClients.Api.DTOs;
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

    public Task<IEnumerable<ClientDto>> GetClients()
    {
        throw new NotImplementedException();
    }

    public Task<ClientDto> GetClientById(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateClient(ClientDto clientDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateClient(int id, ClientDto clientDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteClient(int id)
    {
        throw new NotImplementedException();
    }
}