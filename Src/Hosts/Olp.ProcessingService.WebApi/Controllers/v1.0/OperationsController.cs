using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Olp.Core.ProcessingContracts.Commands;
using Olp.Services.ProcessingAbstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Olp.ProcessingService.WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class OperationsController(
    IOperationService operationService
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
    public async Task<CommandBaseResult> Post([FromBody] CreateProposalCommand command)
    {
        var userId = Guid.NewGuid();

        return await operationService.ExecCommandAsync(userId, command);
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
