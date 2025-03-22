// ReSharper disable UnusedMember.Local

using Linq.Data.Models;

namespace Linq.Cmd._7_CombiningResults;

public class SetOperations : QueryRunner
{
    public override void Run()
    {
        // UnionSequences();
        // UnionSequencesWithOverlap();
        // IntersectSequences();
        // ExceptSequences();
        // ExceptSequencesWithComparer();
        ExceptSequencesByKey();
    }

    /// <summary>
    /// Take all elements that appear in either source.
    /// </summary>
    void UnionSequences()
    {
        var infinitySaga = Repository.GetInfinitySagaMovies();
        var multiverseSaga = Repository.GetMultiverseSagaMovies();

        var allMovies = infinitySaga
            .Union(multiverseSaga);
        
        PrintAll(allMovies);
    }
    
    /// <summary>
    /// Take all elements that appear in either source.
    /// </summary>
    void UnionSequencesWithOverlap()
    {
        var infinitySaga = Repository.GetInfinitySagaMovies();
        var phase3Movies = Repository.GetPhase3Movies();

        var movies = infinitySaga
            .Union(phase3Movies);
        
        PrintAll(movies);
    }
    
    /// <summary>
    /// Take all elements that appear in both sources.
    /// </summary>
    void IntersectSequences()
    {
        var infinitySaga = Repository.GetInfinitySagaMovies();
        var phase3Movies = Repository.GetPhase3Movies();

        var movies = infinitySaga
            .Intersect(phase3Movies);
        
        PrintAll(movies);
    }
    
    /// <summary>
    /// Take all elements that appear in the first sequence, but not the second.
    /// </summary>
    void ExceptSequences()
    {
        var infinitySaga = Repository.GetInfinitySagaMovies();
        var phase3Movies = Repository.GetPhase3Movies();
        
        var movies = infinitySaga
            .Except(phase3Movies);
        
        PrintAll(movies);
    }
    
    /// <summary>
    /// The above operations have overloads for custom comparison.
    /// </summary>
    void ExceptSequencesWithComparer()
    {
        var infinitySaga = Repository.GetInfinitySagaMovies();
        Movie[] phase1Movies = [
            new Movie { Name = "Iron Man", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "The incredible Hulk", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "Iron Man 2", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "Thor", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "Captain America: The first Avenger", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "The Avengers", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
        ];
        
        var movies = infinitySaga
            .Except(phase1Movies, new MovieComparer());
        
        PrintAll(movies);
    }
    
    /// <summary>
    /// The above operations have overloads to select items by key
    /// </summary>
    void ExceptSequencesByKey()
    {
        var infinitySaga = Repository.GetInfinitySagaMovies();
        string[] phase1MovieNames = [
            "Iron Man", "The incredible Hulk", "Iron Man 2",
            "Thor", "Captain America: The first Avenger", "The Avengers"
        ];

        var movies = infinitySaga
            .ExceptBy(phase1MovieNames, movie => movie.Name);
        
        PrintAll(movies);
    }
}

class MovieComparer : IEqualityComparer<Movie>
{
    public bool Equals(Movie? x, Movie? y)
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