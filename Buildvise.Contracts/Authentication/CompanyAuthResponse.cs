namespace Buildvise.Contracts.Authentication;

public record CompanyAuthResponse(
    Guid Id,
    string CompanyName,
    string WorkEmail,
    string CompanyBio,
    string? PhoneNumber,
    string Token);