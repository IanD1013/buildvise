// ReSharper disable UnusedMember.Local
using Linq.Data.Models;

namespace Linq.Cmd._4_OutputFromQueries;

public class DeferredExecution : QueryRunner
{
    public override void Run()
    {
        // SimpleQueryWithForeach();
        // SimpleQueryWithToList();
        // SimpleQueryWithImmediateToList();
        // SimpleQueryWithFirst();
        ExtendedWithForeach();
    }

    /// <summary>
    /// A single query, triggered by iterating over the results
    /// </summary>
    private void SimpleQueryWithForeach()
    {
        var sourceMovies = Repository.GetAllMovies();

        // This defines the LINQ query
        var query =
            from movie in sourceMovies
            where IsSpiderManMovie(movie)
            select movie;

        // Triggering the iterator will start execution
        foreach (var movie in query)
        {
            Console.WriteLine(movie);
        }
    }
    
    /// <summary>
    /// A single query, triggered by materializing to a collection type.
    /// </summary>
    private void SimpleQueryWithToList()
    {
        var sourceMovies = Repository.GetAllMovies();

        // This defines the LINQ query
        var query =
            from movie in sourceMovies
            where IsSpiderManMovie(movie)
            select movie;
        
        // Materializing to a collection will execute the query
        var result = query.ToList();
        
        foreach (var movie in result)
        {
            Console.WriteLine(movie);
        }
    }
    
    /// <summary>
    /// A single query, immediately triggered by materializing to a collection.
    /// </summary>
    private void SimpleQueryWithImmediateToList()
    {
        var sourceMovies = Repository.GetAllMovies();

        // This defines the LINQ query, 
        // and immediately executes it by materializing to a collection
        var result =
            (from movie in sourceMovies
            where IsSpiderManMovie(movie)
            select movie).ToList();
        
        foreach (var movie in result)
        {
            Console.WriteLine(movie);
        }
    }
    
    /// <summary>
    /// A single query, triggered by retrieving a single item.
    /// </summary>
    private void SimpleQueryWithFirst()
    {
        var sourceMovies = Repository.GetAllMovies();

        // This defines the LINQ query
        var query =
            from movie in sourceMovies
            where IsSpiderManMovie(movie)
            select movie;
        
        // Retrieving a single result also triggers execution
        var result = query.First();
        
        Console.WriteLine(result);
    }
    
    /// <summary>
    /// A query that extends another query, triggered by iterating.
    /// </summary>
    private void ExtendedWithForeach()
    {
        var sourceMovies = Repository.GetAllMovies();

        // This defines a LINQ query
        var query =
            from movie in sourceMovies
            where IsSpiderManMovie(movie)
            select movie;
        
        // Extending the query does not trigger execution
        var refinedQuery =
            from movie in query
            where movie.ReleaseDate.Year < 2020
            select movie;

        // Triggering the iterator will start execution
        foreach (var movie in refinedQuery)
        {
            Console.WriteLine(movie);
        }
    }
    
    private static bool IsSpiderManMovie(Movie movie)
    {
        return movie.Name.Contains("Spider-Man");
    }
}