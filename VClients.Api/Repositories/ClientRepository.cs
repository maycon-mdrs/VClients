using Microsoft.EntityFrameworkCore;
using VClients.Api.Context;
using VClients.Api.Models;
using VClients.Api.Repositories.Interfaces;

namespace VClients.Api.Repositories;

public class ClientRepository : IClientRepository
{   
    private readonly AppDbContext _context;
    
    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetById(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> Create(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    /*public Task UpdateClient(ClientModel client)
    {
        return 
    }

    public Task DeleteClient(int id)
    {
        return 
    }*/
}