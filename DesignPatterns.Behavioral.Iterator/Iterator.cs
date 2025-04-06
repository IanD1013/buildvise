namespace DesignPatterns.Behavioral.Iterator;

public interface Iterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}