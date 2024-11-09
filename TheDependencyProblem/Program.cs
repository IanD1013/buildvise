using TheDependencyProblem;

var greeter = new Greeter(new SystemDateTimeProvider()); 

var message = greeter.CreateGreetMessage();
Console.WriteLine(message);