using Buildvise.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buildvise.Infrastructure.Clients.Persistence;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FullName);
        
        builder.Property(c => c.Email);
        
        builder.Property(c => c.Bio);
        
        builder.Property(c => c.PhoneNumber);
        
        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");
    }
}