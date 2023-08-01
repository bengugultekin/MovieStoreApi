using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Application.MovieOperations.Queries;

namespace MovieStoreApi.Application.CustomerOperations.Queries;

public class GetCustomerDetailQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int CustomerId { get; set; }

    public GetCustomerDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public CustomerDetailViewModel Handle()
    {
        var customer = _dbContext.Customers
            .Include(x => x.FavoriteGenres)
            .Include(x => x.BoughtMovies).SingleOrDefault();
        if (customer == null) 
        {
            throw new InvalidOperationException("Müşteri Bulunamadı");
        }

        CustomerDetailViewModel vm = _mapper.Map<CustomerDetailViewModel>(customer);
        return vm;
    }
}

public class CustomerDetailViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<GenreViewModel> FavoriteGenres { get; set; } = new List<GenreViewModel>();
    public List<BoughtMovieModel> BoughtMovies { get; set; } = new List<BoughtMovieModel>();
}