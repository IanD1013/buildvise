using Buildvise.Domain.Companies;

namespace Buildvise.Application.Authentication.Common;

public record CompanyAuthResult(
    Company company,
    string Token);