using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi;

public class Movie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}
