namespace Limitations.Api.Services;

public class TransientService
{
    private readonly SingletonService _singletonService;

    public TransientService(SingletonService singletonService)
    {
        _singletonService = singletonService;
    }

    public Guid Id => _singletonService.Id;// = Guid.NewGuid();
}
