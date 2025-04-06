namespace Limitations.Api.Services;

public class ServiceB
{
    private readonly ServiceA _serviceA;

    public ServiceB(ServiceA serviceA)
    {
        _serviceA = serviceA;
    }
}
