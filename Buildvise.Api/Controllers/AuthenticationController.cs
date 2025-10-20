using Buildvise.Api.Mapping;
using Buildvise.Application.Authentication.Commands.Register;
using Buildvise.Application.Authentication.Common;
using Buildvise.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Buildvise.Api.Controllers;

[Route("[controller]")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/register/client")]
    public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
    {
        var command = request.ToCommand();
        
        var clientAuthResult = await _mediator.Send(command);

        return clientAuthResult.Match(
            authResult => Ok(authResult.ToAuthResponse()),
            Problem
        );
    }
    
    [HttpPost("/register/company")]
    public async Task<IActionResult> RegisterCompany(RegisterCompanyRequest request)
    {
        throw new NotImplementedException();
    }
}