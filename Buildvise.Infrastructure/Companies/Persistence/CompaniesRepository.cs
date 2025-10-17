using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Companies;

namespace Buildvise.Infrastructure.Companies.Persistence;

public class CompaniesRepository : ICompaniesRepository
{
    public Task AddCompanyAsync(Company company)
    {
        throw new NotImplementedException();
    }

    public Task<Company?> GetByIdAsync(Guid companyId)
    {
        throw new NotImplementedException();
    }
}