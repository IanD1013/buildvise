
using DesignPatterns.Behavioral.Iterator;

Aggregate<int> aggregate = new ConcreteAggregate<int>();

aggregate.Add(1);
aggregate.Add(2);
aggregate.Add(3);

Iterator<int> iterator = aggregate.CreateIterator();

while (iterator.HasNext())
{
    Console.WriteLine(iterator.Next());
}