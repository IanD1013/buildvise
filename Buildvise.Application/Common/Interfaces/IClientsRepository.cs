using Buildvise.Domain.Clients;

namespace Buildvise.Application.Common.Interfaces;

public interface IClientsRepository
{
    Task AddClientAsync(Client client);
    Task<bool> ExistsByEmailAsync(string email);
}