using Microsoft.AspNetCore.Mvc;
using Weather.Api.Filter;
using Weather.Api.Service;

namespace Weather.Api.Controllers;

[ApiController]
public class LifetimeController : ControllerBase
{
    private readonly IdGenerator _idGenerator;

    public LifetimeController(IdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    [HttpGet("lifetime")]
    [ServiceFilter(typeof(LifetimeIndicatorFilter))]
    public IActionResult GetId()
    {
        var id = _idGenerator.Id;
        return Ok(id);
    }
}
