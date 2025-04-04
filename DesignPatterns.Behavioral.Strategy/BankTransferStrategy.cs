namespace DesignPatterns.Behavioral.Strategy;

public class BankTransferStrategy(string bankName, string accountNumber) : IPaymentStrategy
{
    private readonly string _bankName = bankName;
    private readonly string _accountNumber = accountNumber;

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using Bank Transfer");
    }
}
