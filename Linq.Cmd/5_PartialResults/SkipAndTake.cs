// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._5_PartialResults;

public class SkipAndTake : QueryRunner
{
    public override void Run()
    {
        // TakeFirstItems();
        // TakeLastItems();
        // TakeMatchingItems();
        // SkipFirstItems();
        // SkipLastItems();
        // SkipMatchingItems();
        GetChunkUsingSkipAndTake();
    }
    
    /// <summary>
    /// Take the first X items from a source
    /// </summary>
    void TakeFirstItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .Take(5);

        PrintAll(result);
    }
    
    /// <summary>
    /// Take the last X items from a source
    /// </summary>
    void TakeLastItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .TakeLast(5);

        PrintAll(result);
    }
    
    /// <summary>
    /// Take items from a source while a condition is true
    /// </summary>
    void TakeMatchingItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .TakeWhile(movie => movie.Phase <= 3);

        PrintAll(result);
    }
    
    /// <summary>
    /// Skip the first X items from a source
    /// </summary>
    void SkipFirstItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .Skip(5);

        PrintAll(result);
    }
    
    /// <summary>
    /// Skip the last X items from a source
    /// </summary>
    void SkipLastItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .SkipLast(5);

        PrintAll(result);
    }
    
    /// <summary>
    /// Skip items from a source while a condition is true
    /// </summary>
    void SkipMatchingItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .SkipWhile(movie => movie.Phase <= 3);

        PrintAll(result);
    }
    
    /// <summary>
    /// Combining Skip & Take to get a chunk of items from a source
    /// </summary>
    void GetChunkUsingSkipAndTake()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .Skip(10)
            .Take(5);

        PrintAll(result);
    }
}