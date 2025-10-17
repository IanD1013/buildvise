using ErrorOr;
using MediatR;

namespace Buildvise.Application.Companies.Commands.CreateCompany;

public record CreateCompanyCommand(string Name): IRequest<ErrorOr<Guid>>;