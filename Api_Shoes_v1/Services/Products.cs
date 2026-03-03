using Api_Shoes_v1.RealModels;
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

        public async Task<List<Shoe>> GetAllProducts()
        {
            return await _context.Shoes.ToListAsync();
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