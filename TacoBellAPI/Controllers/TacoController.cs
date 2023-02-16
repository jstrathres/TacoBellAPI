using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPI.Models;

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }
        //ANY CHANGES TO DB (ADDING OR UPDATING) DONT FORGET TO dbContext.SaveChanges()

        [HttpGet("Id")]
        public Taco GetById(int i)
        {
            return (Taco)dbContext.Tacos.Where(d => d.Id == i);
        }
    }

}
