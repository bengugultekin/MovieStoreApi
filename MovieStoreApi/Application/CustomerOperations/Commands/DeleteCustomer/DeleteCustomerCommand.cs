namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class DeleteCustomerCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    public int CustomerId { get; set; }

    public DeleteCustomerCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == CustomerId);

        if (customer is null) 
        {
            throw new InvalidOperationException("Silinecek Müşteri Bulunamadı");
        }
        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
    }
}
