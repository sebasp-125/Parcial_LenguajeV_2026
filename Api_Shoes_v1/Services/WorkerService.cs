using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Services.IService;

namespace Api_Shoes_v1.Services
{
    public class WorkerService : IWorker
    {
        private readonly DbApiShoesV1Context _context;

        public WorkerService(DbApiShoesV1Context context)
        {
            _context = context;
        }

        public async Task<Worker> CreateWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            return worker;
        }
    }
}
