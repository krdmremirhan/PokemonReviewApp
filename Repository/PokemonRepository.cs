using WebApplication8.Data;
using WebApplication8.Dto;
using WebApplication8.Interface;
using WebApplication8.Models;

namespace WebApplication8.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;
            
    public PokemonRepository(DataContext context)
    {
        _context = context;
    }
    public ICollection<Pokemon> GetPokemons()
    {
        return _context.Pokemon.OrderBy(P => P.Id).ToList();
    }

    public Pokemon GetPokemon(int pokemonId)
    {
        return _context.Pokemon.Where(P => P.Id == pokemonId).FirstOrDefault();
    }

    public Pokemon getPokemon(string name)
    {
        return _context.Pokemon.Where(P => P.Name == name).FirstOrDefault();
    }

    public Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate)
    {
        return GetPokemons().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

    }

    // public Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate)
    // {
    //     throw new NotImplementedException();
    // }

    public decimal GetPokemonRating(int pokeId)
    {
        var review = _context.Reviews.Where(r => r.Pokemon.Id == pokeId);
        if (review.Count() <= 0)
            return 0;
        return ((decimal)review.Sum(r => r.Rating) / review.Count());
    }

    public bool PokemonExists(int pokeId)
    {
        return _context.Pokemon.Any(p => p.Id == pokeId);
    }

    public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

        var pokemonOwner = new PokemonOwner()
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon
        };
        _context.Add(pokemonOwner);
        var PokemonCategory = new PokemonCategory()
        {
            Category = category,
            Pokemon = pokemon
        };   
        _context.Add(PokemonCategory);
        _context.Add(pokemon);
        return Save();
    }

    public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        _context.Update(pokemon);
        return Save();
    }

    public bool DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}