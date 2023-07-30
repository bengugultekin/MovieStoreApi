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


            context.SaveChanges();
        }
    }
}
