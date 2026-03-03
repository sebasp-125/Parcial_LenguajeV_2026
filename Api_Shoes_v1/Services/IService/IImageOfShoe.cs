using Api_Shoes_v1.RealModels;

namespace Api_Shoes_v1.Services.IService
{
    public interface IImageOfShoe
    {
        Task<Imageofshoe> CreateImageOfShoe(Imageofshoe imageOfShoe);
    }
}
