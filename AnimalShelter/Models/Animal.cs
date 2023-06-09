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
    [Range(1, 255, ErrorMessage = "Please enter an age between 1 and 255")]
    public int AnimalAge {get;set;}
  }
}