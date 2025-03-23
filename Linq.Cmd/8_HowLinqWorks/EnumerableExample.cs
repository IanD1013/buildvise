namespace Linq.Cmd._8_HowLinqWorks;

public class EnumerableExample : QueryRunner
{
    public override void Run()
    {
        HomeLinqMethods();
    }

    void HomeLinqMethods()
    {
        var allMovies = Repository.GetAllMovies();

        var result = allMovies
            .MyWhere(movie => movie.Phase == 4)
            .MyFirstOrDefault();
        
        Console.WriteLine(result);
    }
}

public static class MyLinqMethods
{
    public static IEnumerable<T> MyWhere<T>(
        this IEnumerable<T> source,
        Predicate<T> condition)
    {
        foreach (var sourceItem in source)
        {
            if (condition(sourceItem))
                yield return sourceItem;
        }
    }

    public static T? MyFirstOrDefault<T>(this IEnumerable<T> source)
    {
        foreach (var sourceItem in source)
        {
            return sourceItem;
        }

        return default;
    }
}