using System.ComponentModel.DataAnnotations;

namespace Api_Shoes_v1.Dtos.Customers
{
    public class AuthDto
    {
        [Required] 
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
