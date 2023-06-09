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

      if (animalAge > 0)
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Animals.Update(animal);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);
      if (animal != null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpGet("popular")]
    public async Task<ActionResult<IEnumerable<Animal>>> GetPopular()
    {
      List<Animal> animalList = _db.Animals.ToList();
      IEnumerable<IGrouping<string,int>> query = animalList.GroupBy(animal => animal.AnimalType, animal => animal.AnimalAge);
      string popularType = "";
      int maxCount = -1;
      foreach (IGrouping<string,int> typeGroup in query)
      {
        if(maxCount <= typeGroup.Count())
        {
          maxCount = typeGroup.Count();
          popularType = typeGroup.Key;
        }
      }
      IQueryable<Animal> queryPopular = _db.Animals.AsQueryable();
      queryPopular = queryPopular.Where(entry => entry.AnimalType == popularType);
      return await queryPopular.ToListAsync();
    }
  }
}