using Api_Shoes_v1.RealModels;

namespace Api_Shoes_v1.Services.IService
{
    public interface ICategory
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
    }
}
