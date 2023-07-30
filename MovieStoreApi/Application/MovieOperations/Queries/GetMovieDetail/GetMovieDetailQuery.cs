using AutoMapper;

namespace MovieStoreApi.Application.MovieOperations.Queries;

public class GetMovieDetailQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public int MovieId { get; set; }

    public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public MovieDetailViewModel Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x =>x.Id == MovieId);
        if (movie is null)
        {
            throw new InvalidOperationException("Film Bulunamadı");
        }
        MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
        return vm;
    }
}
public class MovieDetailViewModel
{
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}