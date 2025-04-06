namespace Limitations.Api.Services;

public class SingletonService
{
    private readonly ScopedService _scopedService;

    public SingletonService(ScopedService scopedService)
    {
        _scopedService = scopedService;
    }

    public Guid Id => _scopedService.Id;// = Guid.NewGuid();
}
