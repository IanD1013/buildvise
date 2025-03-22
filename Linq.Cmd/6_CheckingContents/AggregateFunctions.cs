// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._6_CheckingContents;

public class AggregateFunctions : QueryRunner
{
    public override void Run()
    {
        // MinimumValue();
        // MinimumItem();
        // MaximumValue();
        // MaximumItem();
        // AverageValue();
        // SumValue();
        // CountItems();
        // AggregateFunctionsWithGroupBy_Q();
        AggregateFunctionsWithGroupBy_F();
    }
    

    /// <summary>
    /// Get the minimum value for a certain expression
    /// </summary>
    void MinimumValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var firstReleaseDate = sourceMovies
            .Min(movie => movie.ReleaseDate);
        
        Console.WriteLine(firstReleaseDate);
    }
    
    /// <summary>
    /// Get the item with the minimum value for a certain expression
    /// </summary>
    void MinimumItem()
    {
        var sourceMovies = Repository.GetAllMovies();

        var firstMovie = sourceMovies
            .MinBy(movie => movie.ReleaseDate);
        
        Console.WriteLine(firstMovie);
    }
    
    /// <summary>
    /// Get the maximum value for a certain expression
    /// </summary>
    void MaximumValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var lastReleaseDate = sourceMovies
            .Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
            .Max(movie => movie.ReleaseDate);
        
        Console.WriteLine(lastReleaseDate);
    }
    
    /// <summary>
    /// Get the item with the maximum value for a certain expression
    /// </summary>
    void MaximumItem()
    {
        var sourceMovies = Repository.GetAllMovies();

        var lastMovie = sourceMovies
            .Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
            .MaxBy(movie => movie.ReleaseDate);
        
        Console.WriteLine(lastMovie);
    }
    
    /// <summary>
    /// Get the average value for a certain expression
    /// </summary>
    void AverageValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var averageProducers = sourceMovies
            .Average(movie => movie.Producers.Count);
        
        Console.WriteLine(averageProducers);
    }
    
    /// <summary>
    /// Get the added value for a certain expression
    /// </summary>
    void SumValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var totalProducers = sourceMovies
            .Sum(movie => movie.Producers.Count);
        
        Console.WriteLine(totalProducers);
    }
    
    /// <summary>
    /// Count the number of items
    /// </summary>
    void CountItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var numberOfMovies = sourceMovies
            .Count();
        
        Console.WriteLine(numberOfMovies);
    }
    
    /// <summary>
    /// Combining the use of aggregate functions with a group by, query syntax
    /// </summary>
    void AggregateFunctionsWithGroupBy_Q()
    {
        var sourceMovies = Repository.GetAllMovies();

        var groupedQuery =
            from movie in sourceMovies
            where movie.Producers.Count > 1
            group movie by movie.Phase into movies
            where movies.Key > 2
            select new
            {
                Movies = movies,
                LastMovie = movies.Max(film => film.ReleaseDate)
            };

        foreach (var phase in groupedQuery)
        {
            Console.WriteLine($"PHASE {phase.Movies.Key} (until {phase.LastMovie}):");
            foreach (var movie in phase.Movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
    
    /// <summary>
    /// Combining the use of aggregate functions with a group by, fluent syntax
    /// </summary>
    void AggregateFunctionsWithGroupBy_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var groupedQuery = sourceMovies
            .Where(movie => movie.Producers.Count > 1)
            .GroupBy(
                movie => movie.Phase,
                movie => movie)
            .Where(phase => phase.Key > 2)
            .Select(group => new
            {
                Movies = group,
                LastMovie = group.Max(film => film.ReleaseDate)
            } );
        

        foreach (var phase in groupedQuery)
        {
            Console.WriteLine($"PHASE {phase.Movies.Key} (until {phase.LastMovie}):");
            foreach (var movie in phase.Movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}