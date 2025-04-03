// client

using DesignPatterns.Behavioral.Memento;

Originator originator = new();
Caretaker caretaker = new();

originator.SetState("State 1");
caretaker.AddMemento(originator.CreateMemento());

originator.SetState("State 2");
caretaker.AddMemento(originator.CreateMemento());

originator.SetState("State 3");
caretaker.AddMemento(originator.CreateMemento());

originator.SetState("State 4");
caretaker.AddMemento(originator.CreateMemento());

originator.Restore(caretaker.GetMemento(index: 0));
Console.WriteLine(originator.GetState());

originator.Restore(caretaker.GetMemento(index: 2));
Console.WriteLine(originator.GetState());

originator.Restore(caretaker.GetMemento(index: 1));
Console.WriteLine(originator.GetState());

originator.Restore(caretaker.GetMemento(index: 3));
Console.WriteLine(originator.GetState());