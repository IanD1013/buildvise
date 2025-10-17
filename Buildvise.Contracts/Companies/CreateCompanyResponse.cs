namespace Buildvise.Contracts.Companies;

public class CreateCompanyResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}