using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPI.Models;

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext(); //gives access to values in database

        [HttpGet]
        public List<Taco> GetAll() //getting them all in a list
        {
            return dbContext.Tacos.ToList();
        }
        //ANY CHANGES TO DB (ADDING OR UPDATING) DONT FORGET TO dbContext.SaveChanges()

        //api/taco/3 ex.
        [HttpGet("{id}")]
        public Taco GetById(int id)
        {
            return dbContext.Tacos.FirstOrDefault(t => t.Id == id);
        }

        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softShell, bool Dorito)
        {
            Taco newTaco = new Taco()
            {
                Name = name,
                Cost = cost,
                SoftShell = softShell,
                Dorito = Dorito
            };

            dbContext.Tacos.Add(newTaco);
            dbContext.SaveChanges();

            return newTaco;
        }

        //api/taco/id?name=newName
        //api/taco/2?name=taco supreme ex.
        [HttpPut("{id}")]
        public Taco ChangeTacoName(int id, string name)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t=>t.Id == id);
            t.Name = name;

            dbContext.Tacos.Update(t);
            dbContext.SaveChanges();

            return t;
        }
    }

}
