using Api_Shoes_v1.RealModels;

namespace Api_Shoes_v1.Services.IService
{
    public interface IWorker
    {
        Task<Worker> CreateWorker(Worker worker);
    }
}
