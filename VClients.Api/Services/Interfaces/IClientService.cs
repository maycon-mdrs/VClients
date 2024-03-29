using VClients.Api.DTOs;

namespace VClients.Api.Services.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetClients();
    Task<ClientDto> GetClientById(int id);
    Task CreateClient(ClientDto clientDto);
    /*Task UpdateClient(int id, ClientDto clientDto);
    Task DeleteClient(int id);*/
}