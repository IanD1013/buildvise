using Linq.Data.Models;

// ReSharper disable StringLiteralTypo

namespace Linq.Data.Repositories;

public class MarvelMovieRepository
{
    public IEnumerable<Movie> GetPhase1Movies()
    {
        return _phase1Movies;
    }

    public IEnumerable<Movie> GetPhase2Movies()
    {
        return _phase2Movies;
    }

    public IEnumerable<Movie> GetPhase3Movies()
    {
        return _phase3Movies;
    }

    public IEnumerable<Movie> GetPhase4Movies()
    {
        return _phase4Movies;
    }

    public IEnumerable<Movie> GetPhase5Movies()
    {
        return _phase5Movies;
    }

    public IEnumerable<Movie> GetInfinitySagaMovies()
    {
        List<Movie> movies = [];
        movies.AddRange(_phase1Movies);
        movies.AddRange(_phase2Movies);
        movies.AddRange(_phase3Movies);
        return movies;
    }

    public IEnumerable<Movie> GetMultiverseSagaMovies()
    {
        List<Movie> movies = [];
        movies.AddRange(_phase4Movies);
        movies.AddRange(_phase5Movies);
        return movies;
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        List<Movie> movies = [];
        movies.AddRange(_phase1Movies);
        movies.AddRange(_phase2Movies);
        movies.AddRange(_phase3Movies);
        movies.AddRange(_phase4Movies);
        movies.AddRange(_phase5Movies);
        return movies;
    }
    
    public List<Movie> GetAllMoviesAsList()
    {
        List<Movie> movies = [];
        movies.AddRange(_phase1Movies);
        movies.AddRange(_phase2Movies);
        movies.AddRange(_phase3Movies);
        movies.AddRange(_phase4Movies);
        movies.AddRange(_phase5Movies);
        return movies;
    }
    
    public IQueryable<Movie> GetAllMoviesAsQueryable()
    {
        List<Movie> movies = [];
        movies.AddRange(_phase1Movies);
        movies.AddRange(_phase2Movies);
        movies.AddRange(_phase3Movies);
        movies.AddRange(_phase4Movies);
        movies.AddRange(_phase5Movies);
        return movies.AsQueryable();
    }

    public Movie GetByName(string name)
    {
        var result = GetAllMovies()
            .First(movie => movie.Name == name);

        return result;
    }

    #region Data

    private readonly List<Movie> _phase1Movies =
    [
        new Movie
        {
            MovieId = Guid.Parse("bc908a6a-926f-4886-a377-ea2ff2b969c4"),
            Name = "Iron Man",
            ReleaseDate = new DateOnly(2008, 05, 02),
            Phase = 1,
            Directors = [new Person("Jon", "Favreau")],
            Producers = [new Person("Avi", "Arad"), new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("2b050b53-bc87-49d0-8634-c1a237021df6"),
            Name = "The incredible Hulk",
            ReleaseDate = new DateOnly(2008, 06, 13),
            Phase = 1,
            Directors = [new Person("Louis", "Leterrier")],
            Producers =
            [
                new Person("Avi", "Arad"),
                new Person("Gale Ann", "Hurd"),
                new Person("Kevin", "Feige")
            ]
        },
        new Movie
        {
            MovieId = Guid.Parse("1e895512-cc2f-484f-ad3c-97bff4a3e60b"),
            Name = "Iron Man 2",
            ReleaseDate = new DateOnly(2010, 05, 07),
            Phase = 1,
            Directors = [new Person("Jon", "Favreau")],
            Producers = [new Person("Kevin", "Feige")]
        },

        new Movie
        {
            MovieId = Guid.Parse("4616ed79-40e4-4772-80bd-c0ac9a58adbf"),
            Name = "Thor",
            ReleaseDate = new DateOnly(2011, 05, 06),
            Phase = 1,
            Directors = [new Person("Kenneth", "Branagh")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("b825bde7-e32f-4739-b4f1-38f31971b190"),
            Name = "Captain America: The first Avenger",
            ReleaseDate = new DateOnly(2011, 07, 22),
            Phase = 1,
            Directors = [new Person("Joe", "Jhonston")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("7e4bf08e-3b72-499e-8c41-06002404b9e7"),
            Name = "The Avengers",
            ReleaseDate = new DateOnly(2012, 05, 04),
            Phase = 1,
            Directors = [new Person("Joss", "Whedon")],
            Producers = [new Person("Kevin", "Feige")]
        }
    ];

    private readonly List<Movie> _phase2Movies =
    [
        new Movie
        {
            MovieId = Guid.Parse("6d75fda6-a101-4b0c-b9b9-78bb909c2914"),
            Name = "Iron Man 3",
            ReleaseDate = new DateOnly(2013, 05, 03),
            Phase = 2,
            Directors = [new Person("Shane", "Black")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("077ba6f0-1856-4d20-9c0c-b7d310981660"),
            Name = "Thor: The Dark World",
            ReleaseDate = new DateOnly(2013, 11, 08),
            Phase = 2,
            Directors = [new Person("Alan", "Taylor")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("10b12b80-64f6-4f10-9520-a463a4e08f32"),
            Name = "Captain America: The Winter Soldier",
            ReleaseDate = new DateOnly(2014, 04, 04),
            Phase = 2,
            Directors = [new Person("Anthony", "Russo"), new Person("Joe", "Russo")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("b3a6f6a0-b048-407a-ab9b-551734c1c019"),
            Name = "Guardians Of the Galaxy",
            ReleaseDate = new DateOnly(2014, 08, 01),
            Phase = 2,
            Directors = [new Person("James", "Gunn")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("6e2a7854-027d-4137-8d97-2d81d0052acc"),
            Name = "Avengers: Age of Ultron",
            ReleaseDate = new DateOnly(2015, 05, 01),
            Phase = 2,
            Directors = [new Person("Joss", "Whedon")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("9ad461e0-c61b-48ca-95f2-5ff9cbc5facc"),
            Name = "Ant-Man",
            ReleaseDate = new DateOnly(2015, 07, 17),
            Phase = 2,
            Directors = [new Person("Peyton", "Reed")],
            Producers = [new Person("Kevin", "Feige")]
        }
    ];

    private readonly List<Movie> _phase3Movies =
    [
        new Movie
        {
            MovieId = Guid.Parse("409948fb-602c-49cc-90d1-f0938ef8600d"),
            Name = "Captain America: Civil War",
            ReleaseDate = new DateOnly(2016, 05, 06),
            Phase = 3,
            Directors = [new Person("Anthony", "Russo"), new Person("Joe", "Russo")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("26beb2c1-402e-4e15-bfdd-378c71a182ae"),
            Name = "Doctor Strange",
            ReleaseDate = new DateOnly(2016, 11, 04),
            Phase = 3,
            Directors = [new Person("Scott", "Derrickson")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("11dacd22-4eb2-40eb-b435-4a396f01b491"),
            Name = "Guardians of the Galaxy Vol. 2",
            ReleaseDate = new DateOnly(2017, 05, 05),
            Phase = 3,
            Directors = [new Person("James", "Gunn")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("d05fc30b-a8a6-424c-b980-0089956e94bf"),
            Name = "Spider-Man: Homecoming",
            ReleaseDate = new DateOnly(2017, 07, 07),
            Phase = 3,
            Directors = [new Person("Jon", "Watts")],
            Producers = [new Person("Kevin", "Feige"), new Person("Amy", "Pascal")]
        },
        new Movie
        {
            MovieId = Guid.Parse("28700644-bb2d-4820-a8ac-931caae0dddf"),
            Name = "Thor: Ragnarok",
            ReleaseDate = new DateOnly(2017, 11, 03),
            Phase = 3,
            Directors = [new Person("Taika", "Waititi")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("e67ee404-820a-4688-8e4f-8b9fd19ebb7f"),
            Name = "Black Panther",
            ReleaseDate = new DateOnly(2018, 02, 16),
            Phase = 3,
            Directors = [new Person("Ryan", "Coogler")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("d001eaee-f0b4-4bca-8ed0-dc7edbc2c6ff"),
            Name = "Avengers: Infinity War",
            ReleaseDate = new DateOnly(2018, 04, 27),
            Phase = 3,
            Directors = [new Person("Anthony", "Russo"), new Person("Joe", "Russo")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("0b6b2937-f441-4c03-a3c3-ec5af6d3a12b"),
            Name = "Ant-Man and the Wasp",
            ReleaseDate = new DateOnly(2018, 07, 06),
            Phase = 3,
            Directors = [new Person("Peyton", "Reed")],
            Producers = [new Person("Kevin", "Feige"), new Person("Stephen", "Broussard")]
        },
        new Movie
        {
            MovieId = Guid.Parse("672886c5-ca81-42cd-a570-2ede9eb1ee6b"),
            Name = "Captain Marvel",
            ReleaseDate = new DateOnly(2019, 03, 08),
            Phase = 3,
            Directors = [new Person("Anna", "Boden"), new Person("Ryan", "Fleck")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("f72b9392-783a-4f0e-95ef-cd067c72acfb"),
            Name = "Avengers: Endgame",
            ReleaseDate = new DateOnly(2019, 04, 26),
            Phase = 3,
            Directors = [new Person("Anthony", "Russo"), new Person("Joe", "Russo")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("5fb3d67f-c1dd-4539-9be3-56b59d896481"),
            Name = "Spider-Man: Far From Home",
            ReleaseDate = new DateOnly(2019, 07, 02),
            Phase = 3,
            Directors = [new Person("Jon", "Watts")],
            Producers = [new Person("Kevin", "Feige"), new Person("Amy", "Pascal")]
        }
    ];

    private readonly List<Movie> _phase4Movies =
    [
        new Movie
        {
            MovieId = Guid.Parse("f2f284b2-8993-465a-975d-073909d5fb7e"),
            Name = "Black Widow",
            ReleaseDate = new DateOnly(2021, 07, 09),
            Phase = 4,
            Directors = [new Person("Cate", "Shortland")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("b01b8aa8-bf94-40a3-8d0b-54ed78f117b3"),
            Name = "Shang-Chi and the Legend of the Ten Rings",
            ReleaseDate = new DateOnly(2021, 09, 03),
            Phase = 4,
            Directors = [new Person("Destin Daniel", "Cretton")],
            Producers = [new Person("Kevin", "Feige"), new Person("Jonathan", "Schwartz")]
        },
        new Movie
        {
            MovieId = Guid.Parse("35403f05-e00a-4f75-b600-5b8e52feeb8b"),
            Name = "Eternals",
            ReleaseDate = new DateOnly(2021, 11, 05),
            Phase = 4,
            Directors = [new Person("Chloé", "Zhao")],
            Producers = [new Person("Kevin", "Feige"), new Person("Nate", "Moore")]
        },
        new Movie
        {
            MovieId = Guid.Parse("0127c709-2ace-4cdd-bff8-39d5088f829d"),
            Name = "Spider-Man: No Way Home",
            ReleaseDate = new DateOnly(2021, 12, 17),
            Phase = 4,
            Directors = [new Person("Jon", "Watts")],
            Producers = [new Person("Kevin", "Feige"), new Person("Amy", "Pascal")]
        },
        new Movie
        {
            MovieId = Guid.Parse("10b655f2-6c9e-4883-9647-84867db206ea"),
            Name = "Doctor Strange in the Multiverse of Madness",
            ReleaseDate = new DateOnly(2022, 05, 06),
            Phase = 4,
            Directors = [new Person("Sam", "Raimi")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("1df79139-42bb-4f2a-8ea1-241449471dab"),
            Name = "Thor: Love and Thunder",
            ReleaseDate = new DateOnly(2022, 07, 08),
            Phase = 4,
            Directors = [new Person("Taika", "Waititi")],
            Producers = [new Person("Kevin", "Feige"), new Person("Brad", "Winderbaum")]
        },
        new Movie
        {
            MovieId = Guid.Parse("74b27263-3edf-447c-9e38-89fc29dda6c2"),
            Name = "Black Panther: Wakanda Forever",
            ReleaseDate = new DateOnly(2022, 11, 11),
            Phase = 4,
            Directors = [new Person("Ryan", "Coogler")],
            Producers = [new Person("Kevin", "Feige"), new Person("Nate", "Moore")]
        }
    ];

    private readonly List<Movie> _phase5Movies =
    [
        new Movie
        {
            MovieId = Guid.Parse("dd45ac08-961f-4709-b66b-1ee60590df19"),
            Name = "Ant-Man and the Wasp: Quantumania",
            ReleaseDate = new DateOnly(2023, 02, 17),
            Phase = 5,
            Directors = [new Person("Peyton", "Reed")],
            Producers = [new Person("Kevin", "Feige"), new Person("Stephen", "Broussard")]
        },
        new Movie
        {
            MovieId = Guid.Parse("5448f5c5-618b-4798-8883-a7a26bcc51af"),
            Name = "Guardians of the Galaxy Vol. 3",
            ReleaseDate = new DateOnly(2023, 05, 05),
            Phase = 5,
            Directors = [new Person("James", "Gunn")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("c95922d9-cfa5-4e94-a307-98843b0e2295"),
            Name = "The Marvels",
            ReleaseDate = new DateOnly(2023, 11, 10),
            Phase = 5,
            Directors = [new Person("Nia", "DaCosta")],
            Producers = [new Person("Kevin", "Feige")]
        },
        new Movie
        {
            MovieId = Guid.Parse("aee4c06b-6513-4cf7-a303-c2e2cdc150a1"),
            Name = "Deadpool & Wolverine",
            ReleaseDate = new DateOnly(2024, 07, 26),
            Phase = 5,
            Directors = [new Person("Shawn", "Levy")],
            Producers =
            [
                new Person("Kevin", "Feige"),
                new Person("Ryan", "Reynolds"),
                new Person("Shawn", "Levy"),
                new Person("Lauren", "Shuler Donner")
            ]
        },
        new Movie
        {
            MovieId = Guid.Parse("cd1c35cd-e95c-4e26-bce7-9bde02db398e"),
            Name = "Captain America: Brave New World",
            ReleaseDate = new DateOnly(2025, 02, 14),
            Phase = 5,
            Directors = [new Person("Julius", "Onah")],
            Producers =
            [
                new Person("Kevin", "Feige"),
                new Person("Nate", "Moore"),
                new Person("Malcolm", "Spellman")
            ]
        },
        new Movie
        {
            MovieId = Guid.Parse("e5441b86-e8df-42ba-b977-ecf5ca1fce49"),
            Name = "Thunderbolts",
            ReleaseDate = new DateOnly(2025, 05, 02),
            Phase = 5,
            Directors = [new Person("Jake", "Schreier")],
            Producers = [new Person("Kevin", "Feige")]
        }
    ];

    #endregion
}