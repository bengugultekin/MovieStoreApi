using AutoMapper;

namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class CreateCustomerCommand
{
    public CreateCustomerModel Model { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCustomerCommand (IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);

        if(customer is not null) 
        {
            throw new InvalidOperationException("Müşteri zaten mevcut");
        }
        customer = _mapper.Map<Customer>(customer);

        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
    }
}

public class CreateCustomerModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int[] FavoriteGenresId { get; set; }
    public int[] BuyedFilmsId { get; set; }
}