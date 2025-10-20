using Buildvise.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buildvise.Infrastructure.Companies.Persistence;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CompanyName);

        builder.Property(c => c.WorkEmail);
        
        builder.Property(c => c.CompanyBio);
        
        builder.Property(c => c.PhoneNumber);
        
        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");
    }
}