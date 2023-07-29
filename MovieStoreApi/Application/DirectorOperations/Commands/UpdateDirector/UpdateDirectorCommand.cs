namespace MovieStoreApi.Application.DirectorOperations.Commands;

public class UpdateDirectorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int DirectorId { get; set; }
    public UpdateDirectorModel model { get; set; }

    public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
        if (director is null)
        {
            throw new InvalidOperationException("Yönetmen Bulunamadı");
        }
        director.FirstName = string.IsNullOrEmpty(model.FirstName.Trim()) ? director.FirstName : model.FirstName;
        director.LastName = string.IsNullOrEmpty(model.LastName.Trim()) ? director.LastName : model.LastName;
        director.DirectedByMovies = model.DirectedByMovies;

        _dbContext.SaveChanges();
    }
}
public class UpdateDirectorModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DirectedByMovies { get; set; }
}