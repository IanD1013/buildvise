// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._7_CombiningResults;

public class JoinCollectionsFromResults : QueryRunner
{
    public override void Run()
    {
        // SelectManyFromProperty_Q();
        // SelectManyFromProperty_F();
        // SelectManyWithProjection_Q();
        SelectManyWithProjection_F();
    }

    /// <summary>
    /// Get all of the items from a collection property of the model
    /// and append them into a single collection, query syntax.
    /// </summary>
    void SelectManyFromProperty_Q()
    {
        var allMovies = Repository.GetAllMovies();

        var allDirectors =
            (from movie in allMovies
            from director in movie.Directors
            orderby director.ToString()
            select director).Distinct();
        
        PrintAll(allDirectors);
    }
    
    /// <summary>
    /// Get all of the items from a collection property of the model
    /// and append them into a single collection, fluent syntax.
    /// </summary>
    void SelectManyFromProperty_F()
    {
        var allMovies = Repository.GetAllMovies();

        var allDirectors = allMovies
            .SelectMany(movie => movie.Directors)
            .OrderBy(director => director.ToString())
            .Distinct();
        
        PrintAll(allDirectors);
    }
    
    /// <summary>
    /// With SelectMany, it is possible to project both the source and the child item
    /// into a new model for the resulting sequence, query syntax
    /// </summary>
    void SelectManyWithProjection_Q()
    {
        var allMovies = Repository.GetAllMovies();

        var allDirectors = 
            from movie in allMovies
            from director in movie.Directors
            select (Movie: movie.Name, Director: director.ToString());
        
        PrintAll(allDirectors);
    }
    
    /// <summary>
    /// With SelectMany, it is possible to project both the source and the child item
    /// into a new model for the resulting sequence, fluent syntax
    /// </summary>
    void SelectManyWithProjection_F()
    {
        var allMovies = Repository.GetAllMovies();

        var allDirectors = allMovies
            .SelectMany(
                movie => movie.Directors,
                (movie, director) => (Movie: movie.Name, Director: director.ToString()));
        
        PrintAll(allDirectors);
    }
}