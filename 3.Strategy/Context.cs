namespace _3.Strategy;

public class Context
{
    private Strategy _strategy = null!;

    public void SetStrategy(Strategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}