using Api_Shoes_v1.Dtos.Customers;

namespace Api_Shoes_v1.Services.IService
{
    public interface IAuth
    {
        Task<string> LogIn(AuthDto auth);

    }
}
