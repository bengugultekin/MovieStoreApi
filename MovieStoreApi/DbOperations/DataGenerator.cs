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
            var actor1 = new Actor
            {
                FirstName = "Victor",
                LastName = "Hugo",
            };
            var actor2 = new Actor
            {
                FirstName = "William",
                LastName = "Shakespeare",
            };
            var actor3 = new Actor
            {
                FirstName = "Stefan",
                LastName = "Zweig",
            };
            var genre1 = new Genre
            {
                Name = "Documentary"
            };
            var genre2 = new Genre
            {
                Name = "Science Fiction"
            };
            var genre3 = new Genre
            {
                Name = "Drama"
            };
            var movie1 = new Movie
            {
                Name = "Interseller",
                GenreId = 1,
                DirectorId = 1,
                PublishDate = new DateTime(2002, 12, 11),
                Price = 50,
                Actors = new List<Actor> { actor1, actor2 }
            };
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
            context.Customers.AddRange(
                new Customer
                {
                    FirstName = "Bengu",
                    LastName = "Gultekin",
                    FavoriteGenres = new List<Genre> { genre1, genre2 },
                    BoughtMovies = new List<Movie> { movie1 }
                }
                );


            context.SaveChanges();
        }
    }
}
