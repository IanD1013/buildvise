namespace DesignPatterns.Behavioral.Strategy;

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}