using Buildvise.Application.Authentication.Commands.Register;
using Buildvise.Application.Authentication.Common;
using Buildvise.Contracts.Authentication;

namespace Buildvise.Api.Mapping;

public static class AuthenticationMappings
{
    public static RegisterClientCommand ToCommand(this RegisterClientRequest request)
    {
        return new RegisterClientCommand(
            request.FullName,
            request.Email,
            request.Bio,
            request.PhoneNumber,
            request.Password);
    }

    public static ClientAuthResponse ToAuthResponse(this ClientAuthResult authResult)
    {
        return new ClientAuthResponse(
            authResult.client.Id,
            authResult.client.FullName,
            authResult.client.Email,
            authResult.client.Bio,
            authResult.client.PhoneNumber,
            authResult.Token);
    }
}