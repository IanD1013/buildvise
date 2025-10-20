namespace Buildvise.Contracts.Authentication;

public record RegisterClientRequest(
    string FullName,
    string Email,
    string Bio,
    string? PhoneNumber,
    string Password);