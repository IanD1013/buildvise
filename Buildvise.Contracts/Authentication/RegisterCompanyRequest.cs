namespace Buildvise.Contracts.Authentication;

public record RegisterCompanyRequest(
    string CompanyName,
    string WorkEmail,
    string Password,
    string CompanyBio,
    string? PhoneNumber);