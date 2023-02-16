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
        
        [HttpGet("{id}")]
        public Drink GetById(int id)
        {
            return dbContext.Drinks.FirstOrDefault(d => d.Id == id);
        }

        [HttpPost]
        public Drink AddDrink(string name, float cost, bool slushie)
        {
            //replaces Method
            Drink newDrink = new Drink()
            {
                Name = name,
                Cost = cost,
                Slushie = slushie              
            };

            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();

            return newDrink;
        }

        [HttpDelete("{id}")]
        public Drink DeleteDrinkById(int id)
        {
            Drink d = dbContext.Drinks.FirstOrDefault(d => d.Id == id);  //LINQ= (i => i.Id == id)
            dbContext.Drinks.Remove(d);
            dbContext.SaveChanges();
            return d;           
        }

        [HttpGet("Slushie")]
        public List<Drink> GetAllBySlushie(bool slushie)
        {
            return dbContext.Drinks.Where(b => b.Slushie == slushie).ToList();
        }
    }
}
