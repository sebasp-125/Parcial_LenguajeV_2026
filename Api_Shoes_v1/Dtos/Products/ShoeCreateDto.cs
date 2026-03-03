namespace Api_Shoes_v1.Dtos.Products
{
    public class ShoeCreateDto
    {
        public string Model { get; set; } = null!;
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public int Categoryid { get; set; }
    }
}
