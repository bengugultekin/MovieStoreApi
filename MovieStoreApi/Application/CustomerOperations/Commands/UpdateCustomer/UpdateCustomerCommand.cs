using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Application.MovieOperations.Queries;

namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class UpdateCustomerCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int CustomerId { get; set; }
    public UpdateCustomerViewModel model { get; set; }

    public UpdateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers
            .Include(x => x.FavoriteGenres)
            .Include(x => x.BoughtMovies)
            .SingleOrDefault(x => x.Id == CustomerId);
        if (customer is null)
        {
            throw new InvalidOperationException("Müşteri Bulunamadı");
        }

        customer.FirstName = model.FirstName;
        customer.LastName = model.LastName;

        // Kontrol ve boş liste oluşturma işlemleri
        customer.FavoriteGenres.Clear();
        if (model.FavoriteGenres != null)
        {
            foreach (var genre in model.FavoriteGenres)
            {
                customer.FavoriteGenres.Add(new Genre { Name = genre.Name });
            }
        }

        customer.BoughtMovies.Clear();
        if (model.BoughtMovies != null)
        {
            foreach (var boughtMovie in model.BoughtMovies)
            {
                customer.BoughtMovies.Add(new Movie
                {
                    Name = boughtMovie.Name,
                    Price = boughtMovie.Price
                });
            }
        }

        _dbContext.SaveChanges();
    }

    private int GetGenreIdByName(string genreName)
    {
        var genre = _dbContext.Genres.FirstOrDefault(g => g.Name == genreName);
        if (genre == null)
        {
            // Eğer belirtilen genreName ile eşleşen bir genre yoksa, burada uygun bir işlem yapabilirsiniz.
            // Örneğin hata fırlatabilir veya yeni bir genre ekleyebilirsiniz.
            throw new InvalidOperationException("Belirtilen tür adı mevcut değil.");
        }
        return genre.Id;
    }


}

public class UpdateCustomerViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<GenreViewModel> FavoriteGenres { get; set; } = new List<GenreViewModel>();
    public List<BoughtMovieModel> BoughtMovies { get; set; } = new List<BoughtMovieModel>();
}
