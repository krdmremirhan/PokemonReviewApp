using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Dto;
using WebApplication8.Interface;
using WebApplication8.Models;

namespace WebApplication8.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly ICountryRepository _countryRepository;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper,
        ICountryRepository countryRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _countryRepository = countryRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Pokemon>))]
    public IActionResult GetCategories()
    {

        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }

        var category = _mapper.Map<PokemonDto>(_categoryRepository.GetCategories());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(category);
    }

    [HttpGet("Pokemon/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByCategoryId(int categoryId)
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(
            _categoryRepository.GetPokemonByCategory(categoryId));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(pokemons);
    }

    [HttpPut("{categoryId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto updatedCategory)
    {
        if (updatedCategory == null)
            return BadRequest(ModelState);

        if (categoryId != updatedCategory.Id)
            return BadRequest(ModelState);

        if (!_categoryRepository.CategoryExists(categoryId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var categoryMap = _mapper.Map<Category>(updatedCategory);

        if (!_categoryRepository.UpdateCategory(categoryMap))
        {
            ModelState.AddModelError("", "Something went wrong updating category");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
    {
        if (categoryCreate == null)
            return BadRequest(ModelState);

        var category = _categoryRepository.GetCategories()
            .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (category != null)
        {
            ModelState.AddModelError("", "Category already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoryMap = _mapper.Map<Category>(categoryCreate);

        if (!_categoryRepository.CreateCategory(categoryMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    [HttpDelete("{categoryId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCategory(int CategoryId)
    {
        if (!_categoryRepository .CategoryExists(CategoryId))
        {
            return NotFound();
        }    
        var categoryToDelete = _categoryRepository.GetCategory(CategoryId);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        } 
        if(!_categoryRepository.DeleteCategory(categoryToDelete))
        {
            ModelState.AddModelError("", "Something went wrong while deleting");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }




// }
        // [HttpPost]
        // [ProducesResponseType(204)]
        // [ProducesResponseType(400)]
        // public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        // {
        //     if (countryCreate == null)
        //         return BadRequest(ModelState);
        //
        //     var country = _countryRepository.GetCountries()
        //         .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper())
        //         .FirstOrDefault();
        //
        //     if (country != null)
        //     {
        //         ModelState.AddModelError("", "Country already exists");
        //         return StatusCode(422, ModelState);
        //     }
        //
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //
        //     var countryMap = _mapper.Map<Country>(countryCreate);
        //
        //     if (!_countryRepository.CreateCountry(countryMap))
        //     {
        //         ModelState.AddModelError("", "Something went wrong while savin");
        //         return StatusCode(500, ModelState);
        //     }
        //
        //     return Ok("Successfully created");
        // }

    
}