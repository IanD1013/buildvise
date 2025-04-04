namespace DesignPatterns.Behavioral.State;

public class ConcreteStateB : State
{
    public void Handle(Context context)
    {
        Console.WriteLine("Concrete state B handles the request");
        context.SetState(new ConcreteStateA());
    }
}