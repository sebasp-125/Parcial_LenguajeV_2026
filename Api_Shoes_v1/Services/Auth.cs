using Api_Shoes_v1.Dtos.Customers;
using Api_Shoes_v1.Services.IService;
using Microsoft.EntityFrameworkCore;
using Api_Shoes_v1.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_Shoes_v1.Services
{
    public class Auth : IAuth
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public Auth(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config; 
        }

        public async Task<string> LogIn(AuthDto auth)
        {
            // Si usas BCrypt, aquí solo buscas por Email y luego verificas el hash (Andres aca es donde debes de colocar todo lo de hash) 
            var user = await _context.Customers
                .FirstOrDefaultAsync(w => w.Email == auth.Email && w.Password == auth.Password);

            if (user == null) return null; 

            return GenerarToken(user);
        }

        private string GenerarToken(Customer user)
        {
            var jwtKey = _config["Jwt:Key"]; 
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.CompleteName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenConfig);
        }
    }
}