using AutoMapper;
using WebApplication8.Data;
using WebApplication8.Interface;
using WebApplication8.Models;

namespace WebApplication8.Repository;

public class OwnerRepository : IOwnerRepository
{
    
    private readonly DataContext _context;
    
    public OwnerRepository(DataContext context)
    {
        _context = context;
    }
    public ICollection<Owner> GetOwners()
    {
        return _context.Owners.ToList();
    }

    public Owner GetOwner(int ownerId)
    {
        return _context.Owners.Where(o=>o.Id == ownerId).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
    {
        return _context.PokemonOwners.Where(p=>p.Pokemon.Id==pokeId).Select(o=>o.Owner).ToList();
    }

    public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
    {
        return _context.PokemonOwners.Where(p => p.OwnerId == ownerId).Select(o => o.Pokemon).ToList();
    }

    public bool OwnerExists(int ownerId)
    {
        return _context.Owners.Any(o=>o.Id == ownerId);
    }

    public bool CreateOwner(Owner owner)
    {
        _context.Add(owner);
        return Save();
    }

    public bool UpdateOwner(Owner owner)
    {
        _context.Update(owner);
        return Save();
    }

    public bool DeleteOwner(Owner owner)
    {
        _context.Remove(owner);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}