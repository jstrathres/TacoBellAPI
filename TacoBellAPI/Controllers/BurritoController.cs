using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPI.Models;

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurritoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        [HttpGet("{id}")]
        public Burrito GetById(int id)
        {
            return dbContext.Burritos.FirstOrDefault(b => b.Id == id);
        }

        //api/burrtio/beans?beans=true
        //api/burrtio/beans?beans=false
        [HttpGet("beans")]
        public List<Burrito> GetAllByBeans(bool beans)
        {
            return dbContext.Burritos.Where(b=>b.Bean==beans).ToList();
        }
    }
}
