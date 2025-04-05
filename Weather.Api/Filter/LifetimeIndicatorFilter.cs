using Microsoft.AspNetCore.Mvc.Filters;
using Weather.Api.Service;

namespace Weather.Api.Filter;

public class LifetimeIndicatorFilter : IActionFilter // essentially a middleware
{
    private readonly IdGenerator _idGenerator;
    private readonly ILogger<LifetimeIndicatorFilter> _logger;

    public LifetimeIndicatorFilter(IdGenerator idGenerator, ILogger<LifetimeIndicatorFilter> logger)
    {
        _idGenerator = idGenerator;
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var id = _idGenerator.Id;
        _logger.LogInformation($"{nameof(OnActionExecuting)} id was: {id}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var id = _idGenerator.Id;
        _logger.LogInformation($"{nameof(OnActionExecuted)} id was: {id}");
    }
}
