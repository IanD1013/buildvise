// ReSharper disable UnusedMember.Local
using Linq.Data.Models;

namespace Linq.Cmd._6_CheckingContents;

public class CompareSequences : QueryRunner
{
    public override void Run()
    {
        // CheckIfSequencesMatch();
        CheckIfSequencesMatchWithComparer();
    }

    /// <summary>
    /// Check if the items in 2 sequences, one-by-one, are equal.
    /// </summary>
    void CheckIfSequencesMatch()
    {
        var phaseOneMovies = Repository.GetPhase1Movies();

        var firstSixMovies = Repository.GetAllMovies()
            .Take(6);

        var areMoviesEqual = phaseOneMovies
            .SequenceEqual(firstSixMovies);
        
        Console.WriteLine(areMoviesEqual);
    }
    
    /// <summary>
    /// Check if the items in 2 sequences, one-by-one, are equal.
    /// With a custom comparer.
    /// </summary>
    void CheckIfSequencesMatchWithComparer()
    {
        Movie[] phaseOneMovies = [
            new Movie { Name = "Iron Man", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "The incredible Hulk", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "Iron Man 2", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "Thor", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "Captain America: The first Avenger", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
            new Movie { Name = "The Avengers", MovieId = Guid.NewGuid(), ReleaseDate = DateOnly.MinValue },
        ];
        
        var firstSixMovies = Repository.GetAllMovies()
            .Take(6);

        var areSequencesEqual = phaseOneMovies
            .SequenceEqual(firstSixMovies, new MovieComparer());
        
        Console.WriteLine(areSequencesEqual);
    }
}