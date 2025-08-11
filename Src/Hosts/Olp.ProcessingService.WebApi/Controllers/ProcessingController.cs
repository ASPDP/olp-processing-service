using Microsoft.AspNetCore.Mvc;
using Olp.ProcessingService.Core;
using Olp.ProcessingService.Core.Domain;
using Olp.ProcessingService.Core.Domain.Entities;
using Olp.ProcessingService.Core.Domain.Interfaces;
using System.Net.Http.Json;

namespace Olp.ProcessingService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessingController : ControllerBase
    {
        private readonly IProcessingService _service;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProcessingController(

            IProcessingService service,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _service = service;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessingTask>> GetById(Guid id, CancellationToken cancellationToken) //пока просто processing task)
        {
        }

    }
}
