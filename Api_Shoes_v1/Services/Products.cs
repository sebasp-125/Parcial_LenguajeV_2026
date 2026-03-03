using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Dtos.Products;
using Api_Shoes_v1.Dtos.Categories;
using Api_Shoes_v1.Dtos.Images;
using Api_Shoes_v1.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Api_Shoes_v1.Services
{
    public class Products : IProductos
    {
        private readonly DbApiShoesV1Context _context;

        public Products(DbApiShoesV1Context context)
        {
            _context = context;
        }

        public async Task<List<ProductResponseDto>> GetAllProducts()
        {
            var products = await _context.Shoes
                .Include(s => s.Category)
                .Include(s => s.Imageofshoes)
                .ToListAsync();

            return products.Select(s => new ProductResponseDto
            {
                Id = s.Id,
                Model = s.Model,
                Size = s.Size,
                Price = s.Price,
                Categoryid = s.Categoryid,
                Category = s.Category != null ? new CategoryResponseDto
                {
                    Id = s.Category.Id,
                    Name = s.Category.Name
                } : null,
                Imageofshoes = s.Imageofshoes.Select(i => new ImageOfShoeResponseDto
                {
                    Id = i.Id,
                    Imagetype = i.Imagetype,
                    Esprincipal = i.Esprincipal,
                    Url = i.Url
                }).ToList()
            }).ToList();
        }

        public async Task<Shoe> GetProductById(int id)
        {
            var shoe = await _context.Shoes.FirstOrDefaultAsync(s => s.Id == id);
            return shoe;
        }

        public async Task<Shoe> CreateProduct(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }
    }
}