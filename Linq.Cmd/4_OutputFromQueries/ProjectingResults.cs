// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._4_OutputFromQueries;

public class ProjectingResults : QueryRunner
{
    public override void Run()
    {
        // SelectSingleProperty_Q();
        // SelectSingleProperty_F();
        // SelectAnonymousType_Q();
        // SelectAnonymousType_F();
        // ProjectToValueTuple_Q();
        // ProjectToValueTuple_F();
        // ProjectToOtherType_Q();
        // ProjectToOtherType_F();
        // MaterializeProjectedResult_Q();
        MaterializeProjectedResult_Q();
    }

    /// <summary>
    /// Getting a single property from the model class, query syntax
    /// </summary>
    void SelectSingleProperty_Q()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = 
            from movie in sourceMovies
            where movie.Name.StartsWith("Iron Man")
            select movie.Name;
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Getting a single property from the model class, fluent syntax
    /// </summary>
    void SelectSingleProperty_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => movie.Name);
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Getting results as an anonymous type, query syntax
    /// </summary>
    void SelectAnonymousType_Q()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = 
            from movie in sourceMovies
            where movie.Name.StartsWith("Iron Man")
            select new { movie.Name, movie.ReleaseDate.Year };
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Getting results as an anonymous type, fluent syntax
    /// </summary>
    void SelectAnonymousType_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => new { movie.Name, movie.ReleaseDate.Year });
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Projecting to a value tuple, query syntax
    /// </summary>
    void ProjectToValueTuple_Q()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = 
            from movie in sourceMovies
            where movie.Name.StartsWith("Iron Man")
            select ( Title: movie.Name, Year: movie.ReleaseDate.Year );
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Projecting to a value tuple, fluent syntax
    /// </summary>
    void ProjectToValueTuple_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => ( Title: movie.Name, Year: movie.ReleaseDate.Year ));
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Projecting to another type, query syntax
    /// </summary>
    void ProjectToOtherType_Q()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = 
            from movie in sourceMovies
            where movie.Name.StartsWith("Iron Man")
            select new MovieTitle(movie.Name, movie.ReleaseDate.Year);
        
        PrintAll(query);
    }
    
    /// <summary>
    /// Projecting to another type, fluent syntax
    /// </summary>
    void ProjectToOtherType_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => new MovieTitle(movie.Name, movie.ReleaseDate.Year));
        
        PrintAll(query);
    }

    /// <summary>
    /// Materialization or single-item selects are compatible
    /// wih projections, query syntax
    /// </summary>
    void MaterializeProjectedResult_Q()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var result = 
            (from movie in sourceMovies
            where movie.Name.StartsWith("Iron Man")
            select new MovieTitle(movie.Name, movie.ReleaseDate.Year))
            .ToList();
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Materialization or single-item selects are compatible
    /// wih projections, fluent syntax
    /// </summary>
    void MaterializeProjectedResult_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => new MovieTitle(movie.Name, movie.ReleaseDate.Year))
            .ToList();
        
        PrintAll(result);
    }
}

internal record MovieTitle(string Title, int Year)
{
    public override string ToString() => $"{Title} ({Year})";
}