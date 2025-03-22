// ReSharper disable UnusedMember.Local

using Linq.Data.Models;

namespace Linq.Cmd._6_CheckingContents;

public class CheckingForSingleItem : QueryRunner
{
    public override void Run()
    {
        // CheckIfItemIsPresent();
        CheckIfItemIsPresentByComparer();
    }

    /// <summary>
    /// Check if an item exists in a source
    /// </summary>
    void CheckIfItemIsPresent()
    {
        var blackWidow = Repository.GetByName("Black Widow");
        
        var sourceMovies = Repository.GetAllMovies();

        var isMoviePresent = sourceMovies.Contains(blackWidow);
        
        Console.WriteLine(isMoviePresent);
    }
    
    /// <summary>
    /// Check if an item exists in a source, using a custom Equality comparer
    /// </summary>
    void CheckIfItemIsPresentByComparer()
    {
        var blackWidow = new Movie
        {
            MovieId = Guid.NewGuid(),
            Name = "Black Widow",
            ReleaseDate = DateOnly.MinValue
        };
        
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .Contains(blackWidow, new MovieComparer());
        
        Console.WriteLine(result);
    }
}

class MovieComparer : IEqualityComparer<Movie>
{
    public bool Equals(Movie x, Movie y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Name == y.Name;
    }

    public int GetHashCode(Movie obj)
    {
        return obj.Name.GetHashCode();
    }
}