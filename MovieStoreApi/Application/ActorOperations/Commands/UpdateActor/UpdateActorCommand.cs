namespace MovieStoreApi.Application.ActorOperations.Commands;

public class UpdateActorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int ActorId { get; set; }
    public UpdateActorViewModel model { get; set; }

    public UpdateActorCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
        if (actor is null)
        {
            throw new InvalidOperationException("Yazar Bulunamadı");
        }
        actor.FirstName = string.IsNullOrEmpty(model.FirstName.Trim()) ? actor.FirstName : model.FirstName;
        actor.LastName = string.IsNullOrEmpty(model.LastName.Trim()) ? actor.LastName : model.LastName;
        actor.StarringMovies = model.StarringMovies;

        _dbContext.SaveChanges();
    }
}
public class UpdateActorViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StarringMovies { get; set; }
}
