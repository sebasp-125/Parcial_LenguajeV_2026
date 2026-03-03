using Api_Shoes_v1.RealModels;

namespace Api_Shoes_v1.Services.IService
{
    public interface IProductos
    {
        Task<List<Shoe>> GetAllProducts();
        Task<Shoe> GetProductById(int id);
        Task<Shoe> CreateProduct (Shoe shoe);
    }
}
