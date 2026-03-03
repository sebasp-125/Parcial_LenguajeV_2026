using Api_Shoes_v1.Dtos.Categories;
using Api_Shoes_v1.Dtos.Images;

namespace Api_Shoes_v1.Dtos.Products
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public int Categoryid { get; set; }
        public CategoryResponseDto? Category { get; set; }
        public List<ImageOfShoeResponseDto> Imageofshoes { get; set; } = new List<ImageOfShoeResponseDto>();
    }
}
