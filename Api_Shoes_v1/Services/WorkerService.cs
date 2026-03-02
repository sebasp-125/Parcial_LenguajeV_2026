using Api_Shoes_v1.Models;
using Api_Shoes_v1.Services.IService;

namespace Api_Shoes_v1.Services
{
    public class WorkerService : IWorker
    {
        private readonly AppDbContext _context;

        public WorkerService(AppDbContext context)
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
