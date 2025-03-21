// ReSharper disable UnusedMember.Local
using Linq.Data.Models;

namespace Linq.Cmd._3_FilteringAndOrdering;

public class Ordering : QueryRunner
{
    public override void Run()
    {
        // SingleOrderBy_Q();
        // SingleOrderByDescending_Q();
        // SingleOrderBy_F();
        // SingleOrderByDescending_F();
        // MultipleOrderBy_Q();
        // MultipleOrderBy_F();
        OrderByCustomComparer_F();
    }

    /// <summary>
    /// Single order by, query syntax
    /// </summary>
    private void SingleOrderBy_Q()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result =
            from movie in sourceMovies
            orderby movie.Name
            select movie;
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Single order by (descending), query syntax
    /// </summary>
    private void SingleOrderByDescending_Q()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result =
            from movie in sourceMovies
            orderby movie.Name descending
            select movie;
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Single order by, fluent syntax
    /// </summary>
    private void SingleOrderBy_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderBy(movie => movie.Name);
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Single order by (descending), fluent syntax
    /// </summary>
    private void SingleOrderByDescending_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderByDescending(movie => movie.Name);
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Multiple order by, query syntax
    /// </summary>
    private void MultipleOrderBy_Q()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result =
            from movie in sourceMovies
            orderby movie.ReleaseDate.Year descending, movie.Name 
            select movie;
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Multiple order by, fluent syntax
    /// </summary>
    private void MultipleOrderBy_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderByDescending(movie => movie.ReleaseDate.Year)
            .ThenBy(movie => movie.Name);
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Single order by using a custom comparer, fluent syntax
    /// </summary>
    private void OrderByCustomComparer_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderBy(movie => movie, new MovieComparer());
        
        PrintAll(result);
    }
}

class MovieComparer : IComparer<Movie>
{
    public int Compare(Movie? first, Movie? second)
    {
        // Same instance
        if (ReferenceEquals(first, second)) return 0;
        
        // Null is smaller than everything
        if (first is null) return -1;
        if (second is null) return 1;
        
        // If the years are different, sort by year
        if (first.ReleaseDate.Year < second.ReleaseDate.Year)
            return -1;
        if (first.ReleaseDate.Year > second.ReleaseDate.Year)
            return 1;
        
        // If the years are equal, sort by name
        return string.Compare(first.Name, second.Name, StringComparison.Ordinal);
    }
}
