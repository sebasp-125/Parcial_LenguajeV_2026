using Api_Shoes_v1.Dtos.Customers;
using Api_Shoes_v1.Services.IService;
using Microsoft.EntityFrameworkCore;
using Api_Shoes_v1.RealModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace Api_Shoes_v1.Services
{
    public class Auth : IAuth
    {
        private readonly DbApiShoesV1Context _context;
        private readonly IConfiguration _config;

        public Auth(DbApiShoesV1Context context, IConfiguration config)
        {
            _context = context;
            _config = config; 
        }

        public async Task<AuthResponseDto?> LogIn(AuthDto auth)
        {
            // Buscar usuario solo por email
            var user = await _context.Customers
                .Include(c => c.Rol)
                .FirstOrDefaultAsync(w => w.Email == auth.Email);

            // Verificar si el usuario existe y la contraseña coincide con el hash
            if (user == null || !BCrypt.Net.BCrypt.Verify(auth.Password, user.Password))
            {
                return null;
            }

            return GenerarToken(user);
        }

        private AuthResponseDto GenerarToken(Customer user)
        {
            var jwtKey = _config["Jwt:Key"]; 
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Completename),
                new Claim(ClaimTypes.Role, user.Rol?.Tiporol ?? "")
            };

            var tokenExpiration = DateTime.UtcNow.AddMinutes(15);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiration,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResponseDto 
            {
                Token = tokenHandler.WriteToken(tokenConfig),
                Rol = user.Rol?.Tiporol,
                TokenTime = tokenExpiration
            };
        }

        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            // Hashear la contraseña con salting automático
            customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}