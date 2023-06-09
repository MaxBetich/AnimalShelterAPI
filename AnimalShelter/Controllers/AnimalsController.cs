using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Linq;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string animalType, int animalAge)
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable();
      if (animalType != null)
      {
        query = query.Where(entry => entry.AnimalType == animalType);
      }

      if (animalAge >= 0)
      {
        query = query.Where(entry => entry.AnimalAge == animalAge);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if  (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await  _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetAnimal), new {id = animal.AnimalId}, animal);
    }
  }
}