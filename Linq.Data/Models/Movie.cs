namespace Linq.Data.Models;

public class Movie
{
    public required Guid MovieId { get; init; }
    public required string Name { get; init; }
    public required DateOnly ReleaseDate { get; init; }
    public int Phase { get; init; }
    public List<Person> Directors { get; set; } = [];
    public List<Person> Producers { get; set; } = [];

    public override string ToString()
    {
        return $"[{MovieId}] {Name} ({ReleaseDate.Year}) - {string.Join(", ", Directors)}";
    }
}