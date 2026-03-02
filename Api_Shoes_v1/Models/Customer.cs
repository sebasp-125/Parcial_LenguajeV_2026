using System.ComponentModel.DataAnnotations;

namespace Api_Shoes_v1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompleteName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
