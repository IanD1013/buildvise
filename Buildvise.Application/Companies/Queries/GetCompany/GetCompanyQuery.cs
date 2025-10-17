using ErrorOr;
using Buildvise.Domain.Companies;
using MediatR;

namespace Buildvise.Application.Companies.Queries.GetCompany;

public record GetCompanyQuery(Guid companyId) : IRequest<ErrorOr<Company>>;