// ReSharper disable UnusedMember.Local
using Linq.Data.Models;

namespace Linq.Cmd._4_OutputFromQueries;

public class GetAllResults : QueryRunner
{
    public override void Run()
    {
        // LoopOverResults();
        // LoopOverQueryableResults();
        // ResultAsGenericList();
        // ResultAsArray();
        ResultAsDictionary();
    }

    /// <summary>
    /// Just iterate over an IEnumerable to get the results.
    /// </summary>
    private void LoopOverResults()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        foreach (var movie in query)
        {
            Console.WriteLine(movie);
        }
    }
    
    /// <summary>
    /// Input interface = output interface.
    /// So this query on an IQueryable is an IQueryable itself 
    /// </summary>
    private void LoopOverQueryableResults()
    {
        var sourceMovies = Repository.GetAllMoviesAsQueryable();
        
        var query = sourceMovies
            .Where(movie => IsSpiderManMovie(movie));

        foreach (var movie in query)
        {
            Console.WriteLine(movie);
        }
    }
    
    /// <summary>
    /// Materializing to a collection type is pretty common too.
    /// </summary>
    private void ResultAsGenericList()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        var result = query.ToList();

        PrintAll(result);
    }
    
    /// <summary>
    /// Apart from lists, there are many collection types to choose from.
    /// </summary>
    private void ResultAsArray()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        var result = query.ToArray();

        PrintAll(result);
    }
    
    /// <summary>
    /// Getting the results out as a dictionary is just a tiny bit different.
    /// </summary>
    private void ResultAsDictionary()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        var result = query.ToDictionary(
            movie => movie.MovieId,
            movie => movie.Name);

        foreach (var movieId in result.Keys)
        {
            Console.WriteLine(result[movieId]);
        }
    }
    
    private static bool IsSpiderManMovie(Movie movie)
    {
        return movie.Name.Contains("Spider-Man");
    }
}