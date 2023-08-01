using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Application.MovieOperations.Queries;

namespace MovieStoreApi.Application.CustomerOperations.Queries;

public class GetCustomersQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCustomersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<CustomersViewModel> Handle()
    {
        var customers = _dbContext.Customers
            .Include(x => x.FavoriteGenres)
            .Include(x => x.BoughtMovies)
            .OrderBy(x => x.Id).ToList();
        List<CustomersViewModel> vm = _mapper.Map<List<CustomersViewModel>>(customers);
        return vm;
    }
}

public class CustomersViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<GenreViewModel> FavoriteGenres { get; set; } = new List<GenreViewModel>();
    public List<BoughtMovieModel> BoughtMovies { get; set; } = new List<BoughtMovieModel>();


}
