using AutoMapper;

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
        var movies = _dbContext.Movies.OrderBy(x => x.Id).ToList();
        List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movies);
        return vm;
    }
}
public class MoviesViewModel
{
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}