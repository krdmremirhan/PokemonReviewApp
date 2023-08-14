using AutoMapper;
using WebApplication8.Data;
using WebApplication8.Interface;
using WebApplication8.Models;

namespace WebApplication8.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CountryRepository(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public ICollection<Country> GetCountries()
    {
        return _context.Countries.ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Countries.Where(C=>C.Id == id).FirstOrDefault();
    }

    public Country GetCountryByOwner(int id)
    {
        return _context.Owners.Where(o=>o.Id == id).Select(c=>c.Country).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnersFromACountry(int countryId)
    {
 
        return  _context.Owners.Where(c=>c.Country.Id == countryId).ToList();
    }

    public bool CreateCountry(Country country)
    {
        _context.Add(country);
        return Save();
    }

    public bool UpdateCountry(Country country)
    {
        _context.Update(country);
        return Save();

    }

    public bool DeleteCountry(Country country)
    {
        _context.Remove(country);
        return Save();
    }

    public bool CountryExists(int id)
    {
        return _context.Countries.Any(c=>c. Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}