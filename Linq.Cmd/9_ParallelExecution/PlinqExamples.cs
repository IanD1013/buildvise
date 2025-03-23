using System.Diagnostics;

namespace Linq.Cmd._9_ParallelExecution;

public class PlinqExamples : QueryRunner
{
    public override void Run()
    {
        // ASlowQueryAppeared();
        // RunInParallel();
        // PreserveOrdering();
        // LimitParallelization();
        // UseForAll();
        // MergingThreadResults();
        ReturnToSequential();
    }

    /// <summary>
    /// This query is artificially slow, taking 1s per item in the source collection.
    /// </summary>
    void ASlowQueryAppeared()
    {
        var allMovies = Repository.GetAllMovies();

        var query =
            from movie in allMovies
            where SlowCondition(movie.Phase < 5)
            select movie;

        PrintAll(query);
    }

    /// <summary>
    /// By running in parallel, we can speed up results.
    /// </summary>
    void RunInParallel()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var allMovies = Repository.GetAllMovies();

        var query = allMovies
            .AsParallel()
            .Where(movie => SlowCondition(movie.Phase < 5));

        PrintAll(query);
        
        Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
    }

    /// <summary>
    /// If we need to keep the order of the source intact
    /// </summary>
    void PreserveOrdering()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var allMovies = Repository.GetAllMovies();

        var query = allMovies
            .AsParallel()
            .AsOrdered()
            .Where(movie => SlowCondition(movie.Phase < 5));

        PrintAll(query);
        
        Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
    }

    /// <summary>
    /// Sometimes we want to limit the number of threads.
    /// </summary>
    void LimitParallelization()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var allMovies = Repository.GetAllMovies();

        var query = allMovies
            .AsParallel()
            .WithDegreeOfParallelism(6)
            .Where(movie => SlowCondition(movie.Phase < 5));

        PrintAll(query);
        
        Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
    }
    
    /// <summary>
    /// Instead of iterating, the pipeline can remain parallel.
    /// </summary>
    void UseForAll()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var allMovies = Repository.GetAllMovies();

        allMovies
            .AsParallel()
            .Where(movie => SlowCondition(movie.Phase < 5))
            .ForAll(movie => Console.WriteLine(movie));
        
        Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
    }
    
    /// <summary>
    /// MergeOptions control how results are returned.
    /// </summary>
    void MergingThreadResults()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var allMovies = Repository.GetAllMovies();

        var query = allMovies
            .AsParallel()
            .WithDegreeOfParallelism(6)
            .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
            .Where(movie => SlowCondition(movie.Phase < 5));

        PrintAll(query);
        
        Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
    }
    
    /// <summary>
    /// You can run the rest of the query in sequence if needed.
    /// </summary>
    void ReturnToSequential()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var allMovies = Repository.GetAllMovies();

        var query = allMovies
            .AsParallel()
            .Where(movie => SlowCondition(movie.Phase < 5))
            .AsSequential()
            .Where(movie => SlowCondition(movie.ReleaseDate.Year > 2011));

        PrintAll(query);
        
        Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
    }

    private bool SlowCondition(bool inputCondition)
    {
        Thread.Sleep(1000);
        return inputCondition;
    }
}
