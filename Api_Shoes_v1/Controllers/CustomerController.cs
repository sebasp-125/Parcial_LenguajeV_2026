using Api_Shoes_v1.Models;
using Api_Shoes_v1.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAuth _authService;

        public CustomerController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("La información del cliente no puede ser nula.");
            }

            // Aquí se podría implementar validación para checar si el email ya existe.
            var createdCustomer = await _authService.RegisterCustomer(customer);
            return Ok(createdCustomer);
        }
    }
}
