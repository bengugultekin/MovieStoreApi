using AutoMapper;

namespace MovieStoreApi.Application.ActorOperations.Commands;

public class CreateActorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateActorViewModel model { get; set; }

    public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.FirstName == model.FirstName && x.LastName == model.LastName);
        if (actor is not null)
        {
            throw new InvalidOperationException("Oyuncu Zaten Mevcut");
        }

        actor = _mapper.Map<Actor>(model);

        _dbContext.Actors.Add(actor);
        _dbContext.SaveChanges();
    }
}
public class CreateActorViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StarringMovies { get; set; }
}