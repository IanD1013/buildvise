using _3.Strategy;

var context = new Context();

context.SetStrategy(new ConcreteStrategyA());
context.ExecuteStrategy();

context.SetStrategy(new ConcreteStrategyB());
context.ExecuteStrategy();