namespace Buildvise.Domain.Companies;

public class Company
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
}