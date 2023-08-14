using WebApplication8.Dto;
using WebApplication8.Models;

namespace WebApplication8.Interface;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(int pokemonId);
    Pokemon getPokemon(string name);
    Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);

    decimal GetPokemonRating(int pokeId);
    bool PokemonExists(int pokeId);
     
    bool CreatePokemon(int ownerId ,int categoryId, Pokemon pokemon);
    bool UpdatePokemon(int ownerId ,int categoryId, Pokemon pokemon);
    
    bool DeletePokemon(Pokemon pokemon);

    
    bool Save();

}