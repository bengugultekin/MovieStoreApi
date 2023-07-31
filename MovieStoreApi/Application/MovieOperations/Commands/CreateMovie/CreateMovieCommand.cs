using AutoMapper;
using MovieStoreApi.Application.ActorOperations.Commands;

namespace MovieStoreApi.Application.MovieOperations.Commands;

public class CreateMovieCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateMovieModel model { get; set; }

    public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Name == model.Name);
        if (movie is not null)
        {
            throw new InvalidOperationException("Film Zaten Mevcut");
        }

        movie = _mapper.Map<Movie>(model);

        _dbContext.Movies.Add(movie);
        _dbContext.SaveChanges();

        // Yeni bir film eklendiğinde, yönetmenin DirectedByMovies özelliği true olmalı
        var director = _dbContext.Directors.FirstOrDefault(x => x.Id == model.DirectorId);
        if (director != null) 
        {
            director.DirectedByMovies = true;
            _dbContext.SaveChanges();
        }
    }
}
public class CreateMovieModel
{
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public int GenreId { get; set; }
    public int DirectorId { get; set; }
    public decimal Price { get; set; }
}