using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Olp.ProcessingService.Core.Contracts.Commands;
using Olp.ProcessingService.Services.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Olp.ProcessingService.WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class OperationsController(
    IOperationService operationService,
    IHttpContextAccessor httpContextAccessor
) : ControllerBase
{
    // GET: api/<OperationsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<OperationsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<OperationsController>
    [HttpPost]
    public async Task<BaseCommandResult> Post([FromBody] BaseCommand commandModel)
    {
        var userIdHeader = httpContextAccessor.HttpContext?.Request.Headers["UserId"].FirstOrDefault()
            ?? throw new InvalidOperationException("Unknown user.");
        Guid userId = Guid.Parse(userIdHeader);

        return await operationService.ExecCommandAsync(userId, commandModel);
    }

    // PUT api/<OperationsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OperationsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
