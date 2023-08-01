using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Application.ActorOperations.Queries;

namespace MovieStoreApi.Application.MovieOperations.Queries;

public class GetMoviesQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    
    public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<MoviesViewModel> Handle()
    {
        var movies = _dbContext.Movies
        .Include(m => m.Actors)
        .Include(m => m.Genre)
        .Include(m => m.Director)
        .OrderBy(x => x.Id)
        .ToList();
        List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movies);

        return vm;
    }
}
public class MoviesViewModel
{
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public decimal Price { get; set; }
    public List<string> Actors { get; set; } = new List<string>();
}

public class BoughtMovieModel
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}