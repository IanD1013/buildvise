namespace DesignPatterns.Behavioral.Strategy;

public class ConcreteStrategyA : Strategy
{
    public void Execute()
    {
        Console.WriteLine("Executing strategy A");
    }
}