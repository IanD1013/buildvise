namespace DesignPatterns.Behavioral.Strategy;

public class CreditCardStrategy(
    string name,
    string cardNumber,
    string cvv,
    string dateOfExpiry) : IPaymentStrategy
{
    private string _name = name;
    private string _cardNumber = cardNumber;
    private string _cvv = cvv;
    private string _dateOfExpiry = dateOfExpiry;

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using credit card");
    }
}
