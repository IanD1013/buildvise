namespace DesignPatterns.Behavioral.Iterator;

public interface Aggregate<T>
{
    Iterator<T> CreateIterator();
    void Add(T value);
}