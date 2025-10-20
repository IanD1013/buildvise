using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Clients;
using Buildvise.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Buildvise.Infrastructure.Clients.Persistence;

public class ClientsRepository : IClientsRepository
{
    private readonly BuildviseDbContext _dbContext;
    
    public ClientsRepository(BuildviseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddClientAsync(Client client)
    {
        await _dbContext.AddAsync(client);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _dbContext.Clients.AnyAsync(client => client.Email == email);
    }
}