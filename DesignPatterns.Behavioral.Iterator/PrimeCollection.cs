namespace DesignPatterns.Behavioral.IPrimeIterator;

public class PrimeCollection(int count): IPrimeCollection
{
    public int Count { get; } = count;
    
    public IPrimeIterator CreateIterator()
    {
        return new PrimeIterator(this);
    }
}