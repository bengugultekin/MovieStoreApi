namespace MovieStoreApi.Application.DirectorOperations.Commands;

public class DeleteDirectorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int DirectorId { get; set; }

    public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);

        if (director is null)
        {
            throw new InvalidOperationException("Silinecek Yönetmen Bulunamadı");
        }
        else if (director.DirectedByMovies == true)
        {
            throw new InvalidOperationException("Yönetmenin yönettiği filmler mevcut. Önce filmleri silin");
        }

        _dbContext.Directors.Remove(director);
        _dbContext.SaveChanges();
    }
}
