namespace Limitations.Api.Services;

public class ServiceA
{
    private readonly ServiceB _serviceB;

    public ServiceA(ServiceB serviceB)
    {
        _serviceB = serviceB;
    }
}
