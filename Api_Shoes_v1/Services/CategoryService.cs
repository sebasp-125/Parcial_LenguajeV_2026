using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Api_Shoes_v1.Services
{
    public class CategoryService : ICategory
    {
        private readonly DbApiShoesV1Context _context;

        public CategoryService(DbApiShoesV1Context context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
