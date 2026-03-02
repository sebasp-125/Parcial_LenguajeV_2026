using Api_Shoes_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("AllProductos")]
        public IActionResult AllProductos()
        {
            var objetoPrueba = new Shoe
            {
                Id = 1,
                Model = "Manzana", 
                Price = 120000,    
                Size = 40          
            };

            return Ok(objetoPrueba);
        }
    }
}
