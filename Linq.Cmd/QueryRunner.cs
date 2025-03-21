using Linq.Data.Repositories;

namespace Linq.Cmd;

public abstract class QueryRunner
{
    protected readonly MarvelMovieRepository Repository = new();

    public abstract void Run();

    protected void Print<T>(T objectToPrint)
    {
        Console.WriteLine(objectToPrint);
    }
    
    protected void PrintAll<T>(IEnumerable<T> objectsToPrint)
    {
        foreach (var objectToPrint in objectsToPrint)
        {
            Console.WriteLine(objectToPrint);
        }
    }
}