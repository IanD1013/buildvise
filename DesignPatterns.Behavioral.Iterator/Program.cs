
using DesignPatterns.Behavioral.IPrimeIterator;

IPrimeCollection primes = new PrimeCollection(count: 5);

IPrimeIterator iterator = primes.CreateIterator();

while (iterator.HasNext())
{
    Console.WriteLine(iterator.Next());
}

iterator.Reset();

while (iterator.HasNext())
{
    Console.WriteLine(iterator.Next());
}