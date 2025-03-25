public class LinqMethods
{
    public void RunExample()
    {
        // LINQ stands for Language Integrated Query
        // We get access to a bunch of LINQ methods in the System.Linq namespace
        // that operate on IEnumerable<T>
        // They're all... extension methods!

        // LINQ can help us
        // - map: transform each item
        // - filter: only take some items
        // - reduce: combine items

        // map: transform each element in a collection
        List<string> rawNumbers = ["1", "2", "3", "4", "5"];

        List<int> numbers = new();
        foreach (string rawNumber in rawNumbers)
        {
            numbers.Add(int.Parse(rawNumber));
        }

        // The basic LINQ method for mapping is Select:
        var numbers2 = rawNumbers
            .Select(number => int.Parse(number))
            .ToList();

        // filter: remove elements from a collection
        List<int> evenNumbers = new();
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }

        // using LINQ we could do...
        var evenNumbers2 = evenNumbers
            .Where(number => number % 2 == 0)
            .ToList();

        // to do a reduction (average in this case) without using LINQ:
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = sum / (double)numbers.Count;

        // We can use Average() from LINQ:
        var averageByLinq = numbers.Average();
                
        // there are MANY more LINQ methods...
        // and we can chain them together to build
        // more complex pipelines!
        List<string> biggerListOfRawNumbers = [ "0", "9", "1", "8", "2", "7", "3", "6", "4", "5"];
        var magicNumber = biggerListOfRawNumbers
            .Select(int.Parse) // converts everything to integers
            .OrderByDescending(number => number) // orders from biggest to smallest number
            .TakeLast(5) // should only take 4, 3, 2, 1, 0
            .Where(number => number % 2 == 0) // should only take 4, 2, 0 (even numbers)
            .Average(); // should be 2
        Console.WriteLine($"The magic number is {magicNumber}!");
///////////////////////////////////////////////////////////////////////////////////////////////////////
 
        // LINQ methods are "lazy" because they are "iterators"
        // they don't do anything until you start enumerating them
        Console.WriteLine("Press enter to start the lazy example.");
        Console.ReadLine();
        Console.WriteLine("Before the LINQ line for lazyNumbersAsStrings");
        var lazyNumbersAsStrings = numbers
            .Select(number =>
            {
                Console.WriteLine($"Transforming {number} to a string");
                return number.ToString();
            });
        Console.WriteLine("After the LINQ line for lazyNumbersAsStrings");

        // force enumeration
        Console.WriteLine("Before forcing enumeration of lazyNumbersAsStrings.");
        lazyNumbersAsStrings.ToArray();
        Console.WriteLine("After forcing enumeration of lazyNumbersAsStrings");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        // this also means you need to be careful if your LINQ is expensive
        // and you keep re-evaluating it because you didn't store the result
        // in a variable!
        Console.WriteLine("Press enter to start expensive operation.");
        Console.ReadLine();
        var expensiveToCalculate = numbers
            .Select(number =>
            {
                Console.WriteLine($"Transforming {number} to a string");
                Thread.Sleep(1000);
                return number.ToString();
            });

        Console.WriteLine("Before first enumeration of expensive operation...");
        foreach (var numberAsString in expensiveToCalculate)
        {
            Console.WriteLine(numberAsString);
        }
        Console.WriteLine("After first enumeration of expensive operation...");

        Console.WriteLine("Before second enumeration of expensive operation...");
        foreach (var numberAsString in expensiveToCalculate)
        {
            Console.WriteLine(numberAsString);
        }
        Console.WriteLine("After second enumeration of expensive operation...");
///////////////////////////////////////////////////////////////////////////////////////////////////
 
        // we can make our own LINQ methods!
        var myLinqResult = numbers
            .NicksFancyLinqMethod(number => number * 2);

        foreach (var number in myLinqResult)
        {
            Console.WriteLine(number);
        }
    }
}

public static class MyLinq
{
    public static IEnumerable<T> NicksFancyLinqMethod<T>(this IEnumerable<T> source, Func<T, T> selector)
    {
        foreach (T item in source)
        {
            Console.WriteLine($"Applying selector to {item}");
            yield return selector(item);
        }
    }
}