// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._5_PartialResults;

public class GroupedResults : QueryRunner
{
    public override void Run()
    {
        // GroupedResults_Q();
        GroupedResults_F();
    }

    /// <summary>
    /// Grouped query results, query syntax
    /// </summary>
    private void GroupedResults_Q()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query =
            from movie in sourceMovies
            where movie.Producers.Count > 1
            group movie by movie.Phase into phase
            where phase.Key > 2
            select phase;

        foreach (var phase in query)
        {
            Console.WriteLine($"PHASE {phase.Key}:");
            foreach (var movie in phase)
            {
                Console.WriteLine(movie);
            }
        }
    }
    
    /// <summary>
    /// Grouped query results, fluent syntax
    /// </summary>
    private void GroupedResults_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var groupedQuery = sourceMovies
            .Where(movie => movie.Producers.Count > 1)
            .GroupBy(
                movie => movie.Phase, // key selector
                movie => movie)       // element selector
            .Where(phase => phase.Key > 2);
        

        foreach (var phase in groupedQuery)
        {
            Console.WriteLine($"Phase {phase.Key}:");
            foreach (var movie in phase)
            {
                Console.WriteLine(movie);
            }
        }
    }
}