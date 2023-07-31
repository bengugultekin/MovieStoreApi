using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi;

public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int[] FavoriteGenresId { get; set; }
    public int[] BuyedFilmsId { get; set; }
    public Genre Genre { get; set; }
    public List<Genre> FavoriteGenres {get; set;}
    public List<Movie> BuyedFilms { get; set;}
}
