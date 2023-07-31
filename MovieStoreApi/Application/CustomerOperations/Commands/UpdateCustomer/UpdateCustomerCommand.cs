namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class UpdateCustomerCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int CustomerId { get; set; }
    public int[] FavoriteGenresId { get; set; }
    public int[] BuyedFilmsId { get; set; }
    public UpdateCustomerViewModel model { get; set; }

    public UpdateCustomerCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == CustomerId);
        if (customer is null) 
        {
            throw new InvalidOperationException("Müşteri Bulunamadı");
        }

        customer.FirstName = string.IsNullOrEmpty(model.FirstName.Trim()) ? customer.FirstName : model.FirstName;
        customer.LastName = string.IsNullOrEmpty(model.LastName.Trim()) ? customer.LastName : model.LastName;
        customer.FavoriteGenresId = model.FavoriteGenresId;
        customer.BuyedFilmsId = model.BuyedFilmsId;

        _dbContext.SaveChanges();
    }

}

public class UpdateCustomerViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int[] FavoriteGenresId { get; set; }
    public int[] BuyedFilmsId { get; set; }
}
