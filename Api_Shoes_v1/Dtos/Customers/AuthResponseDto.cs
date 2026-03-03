namespace Api_Shoes_v1.Dtos.Customers
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string? Rol { get; set; }
        public DateTime TokenTime { get; set; }
    }
}
