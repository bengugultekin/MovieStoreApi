using AutoMapper;

namespace MovieStoreApi.Application.DirectorOperations;

public class CreateDirectorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateDirectorModel model { get; set; }

    public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.FirstName == model.FirstName && x.LastName == model.LastName);
        if (director is not null)
        {
            throw new InvalidOperationException("Yönetmen Zaten Mevcut");
        }

        director = _mapper.Map<Director>(model);

        _dbContext.Directors.Add(director);
        _dbContext.SaveChanges();
    }
}

public class CreateDirectorModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DirectedByMovies { get; set; }
}
