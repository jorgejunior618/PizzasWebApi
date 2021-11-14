using Microsoft.AspNetCore.Mvc;
using ContosoPizzWebAPI.Services;
using ContosoPizzWebAPI.Models;

namespace ContosoPizzWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase 
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => 
            PizzaService.GetAll();
        
        [HttpGet("{id}")]
        public ActionResult<Pizza> GetPizza(int id)
        {
            var pizza = PizzaService.GetPizza(id);

            if(pizza is null) return NotFound();

            return pizza;
        }
    }
}
