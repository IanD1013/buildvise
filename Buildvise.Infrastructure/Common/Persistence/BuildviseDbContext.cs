using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace Buildvise.Infrastructure.Common.Persistence;

public class BuildviseDbContext : DbContext, IUnitOfWork
{
    public DbSet<Company> Companies => Set<Company>();
    
    public BuildviseDbContext(DbContextOptions<BuildviseDbContext> options) : base(options) {}
    
    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}