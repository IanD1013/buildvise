using ErrorOr;
using MediatR;

namespace Buildvise.Application.Companies.Commands.CreateCompany;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }
}