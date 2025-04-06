using TheDependencyProblem;
using TheDependencyProblem.CarExample;

var dieselCar = new Car(new DieselEngine());
var petrolCar = new Car(new PetrolEngine());

var testCar = new Car(new TestEngine());


var greeter = new Greeter(new SystemDateTimeProvider());

var message = greeter.CreateGreetMessage();

Console.WriteLine(message);
