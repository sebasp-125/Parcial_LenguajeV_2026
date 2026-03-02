using Api_Shoes_v1.Models;

namespace Api_Shoes_v1.Services.IService
{
    public interface IWorker
    {
        Task<Worker> CreateWorker(Worker worker);
    }
}
