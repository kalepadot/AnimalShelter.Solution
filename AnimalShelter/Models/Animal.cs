using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name {get; set;}
    public string Gender {get; set;}
    public DateTime DateAdmitted {get; set;}
    public string Breed {get; set;}
  }
}
