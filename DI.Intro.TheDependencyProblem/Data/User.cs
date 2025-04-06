namespace TheDependencyProblem.Data;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FullName { get; set; } = default!;
}
