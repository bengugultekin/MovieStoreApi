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
        _dbContext.Movies.Remove(movie);
        _dbContext.SaveChanges();
    }
}
