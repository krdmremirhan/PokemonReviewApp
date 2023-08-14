using WebApplication8.Data;
using WebApplication8.Interface;
using WebApplication8.Models;

namespace WebApplication8.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;
    
    public CategoryRepository(DataContext context)
    {
        _context = context;
    }
    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
    return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategory(int id)
    {
        return   _context.PokemonCategories.Where(c=>c.CategoryId == id).Select(p=>p.Pokemon).ToList();
    }

    public bool CreateCategory(Category category)
    {
        _context.Add(category);
        _context.SaveChanges();
        return Save();
    }

    public bool UpdateCategory(Category category)
    {
        _context.Update(category);
        return Save();
        
    }

    public bool DeleteCategory(Category category)
    {
        _context.Remove(category);
        return Save();
    }

    public bool CategoryExists(int id)
    {

        return   _context.Categories.Any(c=>c. Id == id);
    }

    public bool Save()
    {
        
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}