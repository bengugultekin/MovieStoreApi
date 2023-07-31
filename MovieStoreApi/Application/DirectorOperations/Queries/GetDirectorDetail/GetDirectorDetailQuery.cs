using AutoMapper;

namespace MovieStoreApi.Application.DirectorOperations.Queries;

public class GetDirectorDetailQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public int DirectorId { get; set; }

    public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public DirectorDetailViewModel Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
        if (director is null)
        {
            throw new InvalidOperationException("Yönetmen Bulunamadı");
        }
        DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);
        return vm;
    }
}
public class DirectorDetailViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool DirectedByMovies { get; set; }

}
