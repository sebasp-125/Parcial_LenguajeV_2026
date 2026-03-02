using Api_Shoes_v1.Models;
using Api_Shoes_v1.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkerController : ControllerBase
    {
        private readonly IWorker _workerService;

        public WorkerController(IWorker workerService)
        {
            _workerService = workerService;
        }

        [HttpPost("AddWorker")]
        public async Task<IActionResult> AddWorker([FromBody] Worker worker)
        {
            if (worker == null)
            {
                return BadRequest("La información del trabajador es nula.");
            }

            var createdWorker = await _workerService.CreateWorker(worker);
            return Ok(createdWorker);
        }
    }
}
