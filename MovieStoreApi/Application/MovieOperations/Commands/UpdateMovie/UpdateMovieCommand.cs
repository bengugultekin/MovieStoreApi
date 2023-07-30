
namespace MovieStoreApi.Application.MovieOperations.Commands;

public class UpdateMovieCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int MovieId { get; set; }
    public UpdateMovieModel model { get; set; }

    public UpdateMovieCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
        if (movie is null)
        {
            throw new InvalidOperationException("Yazar Bulunamadı");
        }
        movie.Name = string.IsNullOrEmpty(model.Name.Trim()) ? movie.Name : model.Name;
        movie.Genre = string.IsNullOrEmpty(model.Genre.Trim()) ? movie.Genre : model.Genre;
        movie.PublishDate = movie.PublishDate;
        movie.Price = model.Price;

        _dbContext.SaveChanges();
    }
}
public class UpdateMovieModel
{
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}