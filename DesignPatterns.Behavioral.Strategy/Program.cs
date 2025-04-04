using DesignPatterns.Behavioral.Strategy;

Context context = new();

context.SetStrategy(new ConcreteStrategyA());
context.ExecuteStrategy();