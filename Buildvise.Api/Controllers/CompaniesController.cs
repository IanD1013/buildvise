using Buildvise.Application.Companies.Commands.CreateCompany;
using Buildvise.Contracts.Companies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Buildvise.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompaniesController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
    {
        var command = new CreateCompanyCommand(request.Name);
        
        var createCompanyResult = await mediator.Send(command);

        return createCompanyResult.MatchFirst(
            guid => Ok(new CreateCompanyResponse { Id = guid, Name = request.Name }),
            error => Problem());
    }
}