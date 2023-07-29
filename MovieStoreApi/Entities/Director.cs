using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi;

public class Director
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DirectedByMovies { get; set; }
}
