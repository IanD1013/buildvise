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
}

