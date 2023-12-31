﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi;

public class Movie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int GenreId { get; set; }
    public int DirectorId { get; set; }
    public DateTime PublishDate { get; set; }
    public Genre Genre { get; set; }
    public Director Director { get; set; }
    public decimal Price { get; set; }
    public ICollection<Actor> Actors { get; set; } = new List<Actor>();
}
