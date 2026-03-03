using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Shoes_v1.Dtos.Customers;
using Api_Shoes_v1.Services.IService;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Auth([FromBody] AuthDto auth)
        {
            var authResponse = await _authService.LogIn(auth);

            if (authResponse == null)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            return Ok(authResponse);
        }
    }
}