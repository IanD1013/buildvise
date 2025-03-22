// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._6_CheckingContents;

public class FindMatches : QueryRunner
{
    public override void Run()
    {
        // CheckIfMatchIsPresent();
        CheckIsAllItemsMatch();
    }

    /// <summary>
    /// Check if there is at least one item that matches the criteria
    /// </summary>
    void CheckIfMatchIsPresent()
    {
        var sourceMovies = Repository.GetAllMovies();

        var isBlackWindowPresent = sourceMovies
            .Any(movie => movie.Name.StartsWith("Iron"));
        
        Console.WriteLine(isBlackWindowPresent);
    }
    
    /// <summary>
    /// Check if all items match the criteria
    /// </summary>
    void CheckIsAllItemsMatch()
    {
        var ironManMovies = Repository.GetAllMovies()
            .Where(movie => movie.Name.StartsWith("Iron Man"));

        var areAllIronManEarlyPhases = ironManMovies
            .All(movie => movie.Phase <= 2);

        Console.WriteLine(areAllIronManEarlyPhases);
    }
    
    
}
