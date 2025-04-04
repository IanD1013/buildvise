namespace DesignPatterns.Behavioral.Strategy;

public class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy = null!;

    public void SetStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}