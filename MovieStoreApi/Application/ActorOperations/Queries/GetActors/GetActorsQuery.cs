using AutoMapper;

namespace MovieStoreApi.Application.ActorOperations.Queries;

public class GetActorsQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<ActorsViewModel> Handle()
    {
        var actors = _dbContext.Actors.OrderBy(x => x.Id).ToList();
        List<ActorsViewModel> vm = _mapper.Map<List<ActorsViewModel>>(actors);
        return vm;
    }
}

public class ActorsViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StarringMovies { get; set; }
}
