using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Dtos.Products;
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
        public async Task<IActionResult> AddProduct([FromBody] ShoeCreateDto shoeDto)
        {
            if (shoeDto == null)
            {
                return BadRequest("El producto es nulo.");
            }

            var shoe = new Shoe
            {
                Model = shoeDto.Model,
                Size = shoeDto.Size,
                Price = shoeDto.Price,
                Categoryid = shoeDto.Categoryid
            };

            var createdShoe = await _productosService.CreateProduct(shoe);
            return Ok(createdShoe);
        }
    }
}
