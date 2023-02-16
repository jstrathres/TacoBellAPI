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

        [HttpGet("Id")]
        public Burrito GetById(int i)
        {
            return (Burrito)dbContext.Burritos.Where(d => d.Id == i);
        }
    }
}
