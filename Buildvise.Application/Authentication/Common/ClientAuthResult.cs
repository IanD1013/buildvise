using Buildvise.Domain.Clients;

namespace Buildvise.Application.Authentication.Common;

public record ClientAuthResult(
    Client client,
    string Token);