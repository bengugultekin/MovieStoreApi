using AutoMapper;

namespace MovieStoreApi.Application.DirectorOperations.Queries;

public class GetDirectorsQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<DirectorsViewModel> Handle()
    {
        var directors = _dbContext.Directors.OrderBy(x => x.Id).ToList();
        List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directors);
        return vm;
    }
}
public class DirectorsViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DirectedByMovies { get; set; }

}