using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi;

public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Genre> FavoriteGenres { get; set; } = new List<Genre>();
    public ICollection<Movie> BoughtMovies { get; set; } = new List<Movie>();
    public ICollection<Movie> BuyMovie { get; set; } = new List<Movie>();
    
}
