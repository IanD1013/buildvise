using Buildvise.Contracts.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Buildvise.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompaniesController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCompany(CreateCompanyRequest request)
    {
        return Ok(request);
    }
}