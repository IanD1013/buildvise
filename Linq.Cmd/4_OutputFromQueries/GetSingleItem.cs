// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._4_OutputFromQueries;

public class GetSingleItem : QueryRunner
{
    public override void Run()
    {
        // GetFirstItem();
        // GetFirstItemWithPredicate();
        // GetLastItem();
        // GetFirstItemWithDefault();
        ExpectSingleMatch();
    }

    /// <summary>
    /// Get the first matching item
    /// </summary>
    void GetFirstItem()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Spider-Man"));

        var result = query.First();

        Print(result);
    }

    /// <summary>
    /// You can add the Where to the Single item operations.
    /// </summary>
    void GetFirstItemWithPredicate()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var result = sourceMovies
            .First(movie => movie.Name.StartsWith("Spider-Man"));

        Print(result);
    }
    
    /// <summary>
    /// You can also retrieve the last item
    /// This only iterates the entire collections depending on the source.
    /// Use the version with predicate to maximize efficiency!
    /// </summary>
    void GetLastItem()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var result = sourceMovies
            .Last(movie => movie.Name.StartsWith("Spider-Man"));
        
        Print(result);
    }
    
    /// <summary>
    /// Adding 'OrDefault' prevents exceptions when no item is found.
    /// </summary>
    void GetFirstItemWithDefault()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var result = sourceMovies
            .FirstOrDefault(movie => movie.Name.StartsWith("Batman"));
        
        Print(result);
    }
    
    /// <summary>
    /// When you only expect a single match, you can throw if more are found.
    /// </summary>
    void ExpectSingleMatch()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var result = sourceMovies
            .Single(movie => movie.Name.StartsWith("Spider-Man: Homecoming"));
        
        Print(result);
    }

    // OVERVIEW:
    //
    // METHOD          | RETURNS     | NO MATCH   | 2+ MATCHES | COMMENTS
    // ----------------+-------------+------------+------------+-------------------------------------------------
    // First           | First match | Throws     | OK         | Stops after first match
    // Last            | Last match  | Throws     | OK         | May iterate entire source
    // Single          | First match | Throws     | Throws     | May iterate entire source, or until second match
    // FirsOrDefault   | First match | default(T) | OK         | Stops after first match
    // LastOrDefault   | Last match  | default(T) | OK         | May iterate entire source
    // SingleOrDefault | First match | default(T) | Throws     | May iterate entire source, or until second match
}