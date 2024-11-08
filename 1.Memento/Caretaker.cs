namespace _1.Memento;

public class Caretaker
{
    private readonly List<Originator.Memento> _mementos = [];

    public void AddMemento(Originator.Memento memento)
    {
        _mementos.Add(memento);
    }

    public Originator.Memento GetMemento(int index)
    {
        return _mementos[index];
    }
}