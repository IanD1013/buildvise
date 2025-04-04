// client

using DesignPatterns.Behavioral.Strategy;

ShoppingCart context = new();

context.SetStrategy(new CreditCardStrategy(
    name: "John Doe",
    cardNumber: "123456789123456",
    cvv: "344",
    dateOfExpiry: "01/28"
));

context.Checkout(100.50m);

context.SetStrategy(new PayPalStrategy(
    email: "john@doe.com",
    password: "mypassword"
));

context.Checkout(10.3m);

context.SetStrategy(new BankTransferStrategy(
    bankName: "MyBank",
    accountNumber: "ABC123"
));

context.Checkout(200m);