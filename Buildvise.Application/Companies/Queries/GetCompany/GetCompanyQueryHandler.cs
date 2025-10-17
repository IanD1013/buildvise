using Buildvise.Application.Common.Interfaces;
using ErrorOr;
using Buildvise.Domain.Companies;
using MediatR;

namespace Buildvise.Application.Companies.Queries.GetCompany;

public class GetCompanyQueryHandler(
    ICompaniesRepository companiesRepository, 
    IUnitOfWork unitOfWork) 
    : IRequestHandler<GetCompanyQuery, ErrorOr<Company>>
{
    public async Task<ErrorOr<Company>> Handle(GetCompanyQuery query, CancellationToken cancellationToken)
    {
        var company = await companiesRepository.GetByIdAsync(query.companyId);

        return company is null
            ? Error.NotFound(description: "Company not found")
            : company;
    }
}