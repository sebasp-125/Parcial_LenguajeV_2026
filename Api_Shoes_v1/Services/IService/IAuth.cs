using Api_Shoes_v1.Dtos.Customers;
using Api_Shoes_v1.RealModels;

namespace Api_Shoes_v1.Services.IService
{
    public interface IAuth
    {
        Task<string> LogIn(AuthDto auth);
        Task<Customer> RegisterCustomer(Customer customer);
    }
}
