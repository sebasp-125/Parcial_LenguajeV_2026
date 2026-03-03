using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Services.IService;

namespace Api_Shoes_v1.Services
{
    public class ImageOfShoeService : IImageOfShoe
    {
        private readonly DbApiShoesV1Context _context;

        public ImageOfShoeService(DbApiShoesV1Context context)
        {
            _context = context;
        }

        public async Task<Imageofshoe> CreateImageOfShoe(Imageofshoe imageOfShoe)
        {
            _context.Imageofshoes.Add(imageOfShoe);
            await _context.SaveChangesAsync();
            return imageOfShoe;
        }
    }
}
