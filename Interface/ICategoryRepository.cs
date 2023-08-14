using WebApplication8.Models;

namespace WebApplication8.Interface;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonByCategory(int id);
    bool CreateCategory(Category category);
    bool UpdateCategory(Category category);
    
    bool DeleteCategory(Category category);

    
    bool CategoryExists(int id);
    
    bool Save();
    
}