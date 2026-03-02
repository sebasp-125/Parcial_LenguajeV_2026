using Api_Shoes_v1.Models;
using Api_Shoes_v1.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductos _productosService;

        public ProductController(IProductos productosService)
        {
            _productosService = productosService;
        }

        [HttpGet("AllProductos")]
        public async Task<IActionResult> AllProductos()
        {
            var productos = await _productosService.GetAllProducts();
            return Ok(productos);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Shoe shoe)
        {
            if (shoe == null)
            {
                return BadRequest("El producto es nulo.");
            }

            var createdShoe = await _productosService.CreateProduct(shoe);
            return Ok(createdShoe);
        }
    }
}
