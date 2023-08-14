namespace WebApplication8.Models;

public class PokemonCategory
{
 
    public int CategoryId { get; set; }
    public int PokemonId { get; set; }
    public Category Category { get; set; }
    public Pokemon Pokemon { get; set; }
}