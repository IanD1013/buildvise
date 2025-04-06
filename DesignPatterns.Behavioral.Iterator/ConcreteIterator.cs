namespace DesignPatterns.Behavioral.Iterator;

public class ConcreteIterator<T>(ConcreteAggregate<T> aggregate) : Iterator<T>
{
    private readonly ConcreteAggregate<T> _aggregate = aggregate;
    private int _currentIndex = -1; 
    
    public bool HasNext()
    {
        return _currentIndex < _aggregate.Count - 1;
    }

    public T Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more elements");
        }
        
        _currentIndex++;
        return _aggregate.GetItemAt(_currentIndex);
    }

    public void Reset()
    {
        _currentIndex = -1; 
    }
}