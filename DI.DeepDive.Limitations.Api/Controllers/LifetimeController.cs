using Limitations.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Limitations.Api.Controllers;

[ApiController]
public class LifetimeController : ControllerBase
{
    private readonly SingletonService _singletonService;
    private readonly TransientService _transientService;
    private readonly ScopedService _scopedService;

    public LifetimeController(ScopedService scopedService, TransientService transientService, SingletonService singletonService)
    {
        _scopedService = scopedService;
        _transientService = transientService;
        _singletonService = singletonService;
    }

    [HttpGet("lifetime")]
    public IActionResult Get()
    {
        var ids = new
        {
            SingletonId = _singletonService.Id,
            TransientId = _transientService.Id,
            ScopedId = _scopedService.Id
        };
        return Ok(ids);
    }
}
