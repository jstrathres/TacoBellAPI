using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPI.Models;
using Microsoft.Extensions.Primitives;

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        public TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        [HttpGet("Id")]
        public Drink GetById(int i)
        {
            return (Drink)dbContext.Drinks.Where(d => d.Id == i);
        }

        [HttpPost]
        public Drink AddDrink(int id, string name, float cost, bool slushie)
        {
            Drink newDrink = new Drink(id, name, cost, slushie);
            dbContext.Drinks.Add(newDrink);

            return newDrink;  //common practice to return new object...newBook is just default naming
        }

        [HttpDelete]
        public Drink DeleteBook(string name)
        {
            Drink d = dbContext.Drinks.FirstOrDefault(d => d.Name == name);
            dbContext.SaveChanges();
            return d;           
        }
    }
}
