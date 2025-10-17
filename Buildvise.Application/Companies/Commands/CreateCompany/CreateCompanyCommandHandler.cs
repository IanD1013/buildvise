using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Companies;
using ErrorOr;
using MediatR;

namespace Buildvise.Application.Companies.Commands.CreateCompany;

public class CreateCompanyCommandHandler(
    ICompaniesRepository companiesRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCompanyCommand, ErrorOr<Company>>
{
    public async Task<ErrorOr<Company>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Id = Guid.NewGuid(), 
            Name = request.Name
        };
        
        await companiesRepository.AddCompanyAsync(company);
        await unitOfWork.CommitChangesAsync();
        
        return company;
    }
}