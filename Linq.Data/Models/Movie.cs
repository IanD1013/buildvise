namespace Linq.Data.Models;

public class Movie
{
    public required Guid MovieId { get; set; }
    public required string Name { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public List<Person> Directors { get; set; } = [];
    public List<Person> Producers { get; set; } = [];

    public override string ToString()
    {
        return $"[{MovieId}] {Name} ({ReleaseDate.Year}) - {string.Join(", ", Directors)}";
    }
}