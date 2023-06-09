using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    public string AnimalType { get; set; }
    [Required]
    public string AnimalName { get; set; }
    [Required]
    public int AnimalAge {get;set;}
  }
}