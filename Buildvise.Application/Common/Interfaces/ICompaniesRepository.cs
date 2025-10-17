using Buildvise.Domain.Companies;

namespace Buildvise.Application.Common.Interfaces;

public interface ICompaniesRepository
{
    Task AddCompanyAsync(Company company);
    Task<Company?> GetByIdAsync(Guid companyId);
}