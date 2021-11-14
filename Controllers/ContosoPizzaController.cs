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
        
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(
                nameof(Create),
                new { id = pizza.Id },
                pizza
            );
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();
            
            var pizzaOnDB = PizzaService.GetPizza(id);

            if(pizzaOnDB is null) return NotFound();

            PizzaService.Update(pizza);

            return(NoContent());
        }
    }
}
