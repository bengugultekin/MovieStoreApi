namespace MovieStoreApi.Application.MovieOperations.Commands;

public class DeleteMovieCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int MovieId { get; set; }

    public DeleteMovieCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);

        if (movie is null)
        {
            throw new InvalidOperationException("Silinecek Film Bulunamadı");
        }

        int directorId = movie.DirectorId;

        _dbContext.Movies.Remove(movie);
        _dbContext.SaveChanges();

        // Filme ait DirectorId başka bir film yönetmeni değilse Director.DirectedByMovies özelliği false olarak değişmeli
        var directorMovies = _dbContext.Movies.Any(x => x.DirectorId == directorId && x.Id != MovieId);
        var director = _dbContext.Directors.FirstOrDefault(x => x.Id == directorId);

        if(director != null && !directorMovies) 
        {
            director.DirectedByMovies = false;
            _dbContext.SaveChanges();
        }
    }
}
