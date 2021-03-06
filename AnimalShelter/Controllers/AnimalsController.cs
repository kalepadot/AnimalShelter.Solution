using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // // Sort the Pet objects in the array by Pet.Age.
    // IEnumerable<Animal> query =
    //     animals.AsQueryable().OrderBy(animal => animal.Name);


    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      model.Sort((x, y) => string.Compare(x.Name, y.Name));
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }

    // public ActionResult ShowSorted(string searchTerm)
    // {
    //   List<Animal> model = _db.Animals.ToList();
    //   List<Animal> sortedModel = model.OrderBy(animal => animal.Breed).ToList();
    //   return SortedIndex(sortedModel);
    // }
  }
}