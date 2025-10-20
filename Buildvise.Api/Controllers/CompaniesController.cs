// using Buildvise.Application.Companies.Commands.CreateCompany;
// using Buildvise.Application.Companies.Queries.GetCompany;
// using Buildvise.Contracts.Companies;
// using MediatR;
//
// using Microsoft.AspNetCore.Mvc;
//
// namespace Buildvise.Api.Controllers;
//
// [Route("[controller]")]
// public class CompaniesController(ISender mediator) : ApiController
// {
//     [HttpPost]
//     public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
//     {
//         var command = new CreateCompanyCommand(request.Name);
//         
//         var createCompanyResult = await mediator.Send(command);
//
//         return createCompanyResult.Match(
//             company => CreatedAtAction(nameof(GetCompany), 
//                 new { companyId = company.Id }, 
//                 new CompanyResponse { Id = company.Id, Name = company.Name }),
//             Problem);
//     }
//
//     [HttpGet("{companyId:guid}")]
//     public async Task<IActionResult> GetCompany(Guid companyId)
//     {
//         var query = new GetCompanyQuery(companyId);
//
//         var getCompanyResult = await mediator.Send(query);
//
//         return getCompanyResult.Match(
//             company => Ok(new CompanyResponse { Id = company.Id, Name = company.Name }),
//             Problem);
//     }
// }