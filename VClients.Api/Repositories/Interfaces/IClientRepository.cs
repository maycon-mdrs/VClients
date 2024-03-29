using VClients.Api.Models;

namespace VClients.Api.Repositories.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAll();
    Task<Client> GetById(int id);
    Task<Client> Create(Client client);
    /*Task UpdateClient(ClientModel client);
    Task DeleteClient(int id);*/
}