namespace Buildvise.Contracts.Companies;

public class CompanyResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}