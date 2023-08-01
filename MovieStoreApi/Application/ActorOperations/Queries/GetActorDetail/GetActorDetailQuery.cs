using AutoMapper;

namespace MovieStoreApi.Application.ActorOperations.Queries;

public class GetActorDetailQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public int ActorId { get; set; }

    public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ActorDetailViewModel Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
        if (actor is null)
        {
            throw new InvalidOperationException("Oyuncu Bulunamadı");
        }
        ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);
        return vm;
    }
}
public class ActorDetailViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}