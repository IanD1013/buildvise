namespace Buildvise.Contracts.Authentication;

public record ClientAuthResponse(
    Guid Id,
    string FullName,
    string Email,
    string Bio,
    string? PhoneNumber,
    string Token
   );