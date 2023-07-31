using Microsoft.EntityFrameworkCore;

namespace MovieStoreApi;

public interface IMovieStoreDbContext
{
    DbSet<Movie> Movies { get; set; }
    DbSet<Actor> Actors { get; set; }
    DbSet<Director> Directors { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Customer> Customers { get; set; }

    int SaveChanges();
}
