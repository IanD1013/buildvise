using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Companies;
using Buildvise.Infrastructure.Common.Persistence;

namespace Buildvise.Infrastructure.Companies.Persistence;

public class CompaniesRepository : ICompaniesRepository
{
    private readonly BuildviseDbContext _dbContext;

    public CompaniesRepository(BuildviseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCompanyAsync(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
    }

    public async Task<Company?> GetByIdAsync(Guid companyId)
    {
        return await _dbContext.Companies.FindAsync(companyId);
    }
}