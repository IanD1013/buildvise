namespace DesignPatterns.Behavioral.IPrimeIterator;

public interface IPrimeIterator
{
    bool HasNext();
    int Next();
    void Reset();
}