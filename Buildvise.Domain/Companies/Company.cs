using Buildvise.Domain.Common;
using Buildvise.Domain.Common.Interfaces;

namespace Buildvise.Domain.Companies;

public class Company : Entity
{
    public string CompanyName { get; } = null!;
    public string WorkEmail { get; } = null!;
    public string CompanyBio { get; } = null!;
    public string? PhoneNumber { get; }
    // public string QualificationFile { get; } = null!;
    
    private readonly string _passwordHash = null!;
    
    public Company(
        string companyName,
        string workEmail,
        string companyBio,
        string passwordHash,
        // string qualificationFile,
        string? phoneNumber = null,
        Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        CompanyName = companyName;
        WorkEmail = workEmail;
        CompanyBio = companyBio;
        // QualificationFile = qualificationFile;
        PhoneNumber = phoneNumber;
        _passwordHash = passwordHash;
    }
    
    public bool IsCorrectPasswordHash(string password, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);   
    }

    private Company()
    {
    }
}