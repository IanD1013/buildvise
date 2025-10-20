using Buildvise.Domain.Clients;
using Buildvise.Domain.Companies;

namespace Buildvise.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(object entity);
}