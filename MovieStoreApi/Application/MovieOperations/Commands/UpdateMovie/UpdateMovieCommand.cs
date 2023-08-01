
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
            throw new InvalidOperationException("Film Bulunamadı");
        }

        int oldDirectorId = movie.DirectorId;

        movie.Name = string.IsNullOrEmpty(model.Name.Trim()) ? movie.Name : model.Name;
        movie.GenreId = model.GenreId != default ? model.GenreId : movie.GenreId;
        movie.DirectorId = model.DirectorId != default ? model.DirectorId : movie.DirectorId;
        movie.PublishDate = model.PublishDate != default ? model.PublishDate : movie.PublishDate;
        movie.Price = model.Price != default ? model.Price : movie.Price;

        movie.Actors.Clear();
        var actors = CheckIfPlayerExist();

        foreach (var actor in actors)
        {
            movie.Actors.Add(actor);
        }

        _dbContext.SaveChanges();

        // Director bilgisi güncellendiğinde, eğer director ün başka yönettiği film yoksa DirectedByMovies false olmalı
        var directorMovies = _dbContext.Movies.Any(x => x.DirectorId == oldDirectorId && x.Id != MovieId);
        var director = _dbContext.Directors.FirstOrDefault(x => x.Id == oldDirectorId);

        if(director != null && !directorMovies) 
        {
            director.DirectedByMovies = false;
            _dbContext.SaveChanges();
        }

        // Güncellenen yönetmenin DirectedByMovies özelliğini true yapalım
        var updatedDirector = _dbContext.Directors.FirstOrDefault(x => x.Id == movie.DirectorId);
        if(updatedDirector != null)
        {
            updatedDirector.DirectedByMovies = true;
            _dbContext.SaveChanges();
        }
    }

    private List<Actor> CheckIfPlayerExist()
    {
        List<Actor> actors = new List<Actor>();
        foreach (int actorsId in model.ActorsId)
        {
            Actor? searchedActor = _dbContext.Actors.SingleOrDefault(x => x.Id == actorsId);

            if (searchedActor == null)
            {
                throw new InvalidOperationException("Aktör Mevcut Değil");
            }

            actors.Add(searchedActor);
        }

        return actors;
    }
}
public class UpdateMovieModel
{
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public int GenreId { get; set; }
    public int DirectorId { get; set; }
    public decimal Price { get; set; }
    public List<int> ActorsId { get; set; } = new List<int>();
}