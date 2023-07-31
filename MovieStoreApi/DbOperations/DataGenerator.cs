using Microsoft.EntityFrameworkCore;

namespace MovieStoreApi;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
        {
            if (context.Actors.Any())
            {
                return;
            }
            context.Actors.AddRange(
                new Actor
                {
                    FirstName = "Victor",
                    LastName = "Hugo",
                    StarringMovies = "first"
                },
                new Actor
                {
                    FirstName = "William",
                    LastName = "Shakespeare",
                    StarringMovies = "first"
                },
                new Actor
                {
                    FirstName = "Stefan",
                    LastName = "Zweig",
                    StarringMovies = "first"
                }
                );
            context.Genres.AddRange(
                new Genre
                {
                    Name = "Documentary"
                },
                new Genre
                {
                    Name = "Science Fiction"
                },
                new Genre
                {
                    Name = "Drama"
                }
                );
            context.Movies.AddRange(
                new Movie
                {
                    Name = "Interseller",
                    GenreId = 1,
                    DirectorId = 1,
                    PublishDate = new DateTime(2002, 12, 11),
                    Price = 50,
                }
                );
            context.Directors.AddRange(
                new Director
                {
                    FirstName = "Harry",
                    LastName = "Ericson",
                    DirectedByMovies = true,
                },
                new Director
                {
                    FirstName = "Daniel",
                    LastName = "Black",
                    DirectedByMovies = false,
                }
                );


            context.SaveChanges();
        }
    }
}
