namespace DesignPatterns.Behavioral.State;

public class ConcreteStateA : State
{
    public void Handle(Context context)
    {
        Console.WriteLine("Concrete state A handles the request");
        context.SetState(new ConcreteStateB());
    }
}