using Buildvise.Domain.Common;
using Buildvise.Domain.Common.Interfaces;

namespace Buildvise.Domain.Clients;

public class Client : Entity
{
    public string FullName { get; } = null!;
    public string Email { get; } = null!;
    public string Bio { get; } = null!;
    public string? PhoneNumber { get; }
    
    private readonly string _passwordHash = null!;

    public Client(
        string fullName,
        string email,
        string bio,
        string passwordHash,
        string? phoneNumber = null,
        Guid? id = null) 
        : base(id ?? Guid.NewGuid())
    {
        FullName = fullName;
        Email = email;
        Bio = bio;
        PhoneNumber = phoneNumber;
        _passwordHash = passwordHash;
    }

    public bool IsCorrectPasswordHash(string password, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);   
    }
    
    private Client()
    {
    }
}