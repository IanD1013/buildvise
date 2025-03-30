//global using NicksColor = (byte R, byte G, byte B);
public class Tuples
{
    public void RunExample()
    {    
        // Tuples are a lightweight data transfer object
        // that can contain multiple values of different types

        // Tuples in C# come in two different flavors:
        // 1. System.Tuple:
        //    - reference type
        //    - immutable
        //    - values are properties
        // 2. System.ValueTuple: a value type
        //    - value type
        //    - mutable
        //    - values are fields
        // ... That's not confusing, right? :)

        // let's see how these look:

        // System.Tuple
        Tuple<int, string> tuple = new Tuple<int, string>(1, "one");

        // System.ValueTuple
        ValueTuple<int, string> valueTuple = new ValueTuple<int, string>(1, "one");
        ValueTuple<int, string> valueTuple2 = new(1, "one");
        ValueTuple<int, string> valueTuple3 = (1, "one");
        var valueTuple4 = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16); // ... and so on!

        // there's a LOT going on here already!
        // - we have generics in both cases
        // - the type parameters are for each of the items the tuple will hold
        // - we know we have reference vs value types here
        // - ... look at the syntax for the ValueTuple!
        // - ValueTuples can take in an arbitrary number of elements


        // tuples are useful for things like:
        // - returning multiple values from a method
        // - passing multiple values to a method
        // - grouping multiple values together
        // ... all without having to go make a dedicated class!

        // how would we return a min AND max from a method before tuples?
        // - use out parameters (yuck!)
        // - use a custom return type
        int GetMinAndMaxWithOutParam(int[] numbers, out int max)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException(
                    "Cannot find min and max of an empty array");
            }

            int min = numbers[0];
            max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return min;
        }

        // this is pretty gross, right?
        int[] numbers = { 1, 2, 3, 4, 5 };
        int min = GetMinAndMaxWithOutParam(numbers, out int max);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // let's see how we can do this with a tuple
        (int, int) GetMinAndMaxWithTuple(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException(
                    "Cannot find min and max of an empty array");
            }

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return (min, max);
        }

        Console.WriteLine("Min and Max with tuple:");
        var minAndMaxTuple = GetMinAndMaxWithTuple(numbers);
        Console.WriteLine($"Min: {minAndMaxTuple.Item1}, Max: {minAndMaxTuple.Item2}");
        Console.WriteLine($"The whole tuple: {minAndMaxTuple}");
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // but we can do EVEN better with named tuples!
        (int Min, int Max) GetMinAndMaxWithNamedTuple(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException(
                    "Cannot find min and max of an empty array");
            }

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return (Min: min, Max: max);
            //return (min, max); // this also works
        }

        Console.WriteLine("Min and Max with named tuple:");
        var minAndMaxNamedTuple = GetMinAndMaxWithNamedTuple(numbers);
        Console.WriteLine($"Min: {minAndMaxNamedTuple.Min}, Max: {minAndMaxNamedTuple.Max}");
        Console.WriteLine($"The whole tuple: {minAndMaxNamedTuple}");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // we can also "deconstruct" tuples
        (int firstThing, string secondThing) = (1, "this is the second thing!");
        //(int minVal, _) = GetMinAndMaxWithNamedTuple(numbers);

        // we can put the keyword var out the front
        // this way to infer the type at compile time
        var (firstThing2, secondThing2) = (1, "this is the second thing!");
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // C# 12 introduced global usings, and we can alias tuples this way!
        //NicksColor color = (R: 255, G: 0, B: 0);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Remember that whole thing about equality challenges from
        // earlier in this course?
        // ... well how does equality work for these?

        (int, string, int) tupleA = (123, "hello", 456);
        (int, int) tupleB = (123, 456);
        (float, float) tupleC = (FirstNumber: 123, SecondNumber: 456);
        (byte, string, float) tupleD = (FirstNumber: 123, Name: "hello", SecondNumber: 456);
        (int, int) tupleE = (456, 789);
        (byte, string, float) tupleF = (123, "world", 456);
        (string, string) tupleG = ("hello", "world");

        // will not compile!
        // need to have same number of elements and compatible types
        //Console.WriteLine($"tupleA == tupleB: {tupleA == tupleB}"); // different counts
        //Console.WriteLine($"tupleA == tupleC: {tupleA == tupleC}"); // different counts
        //Console.WriteLine($"tupleB == tupleG: {tupleB == tupleG}"); // same counts, incompatible types

        Console.WriteLine($"tupleA == tupleD: {tupleA == tupleD}"); // true
        Console.WriteLine($"tupleA == tupleF: {tupleA == tupleF}"); // false
        Console.WriteLine($"tupleB == tupleC: {tupleB == tupleC}"); // true
        Console.WriteLine($"tupleB == tupleE: {tupleB == tupleE}"); // false

        // the .Equals method is not supported for this kind of comparison
        // ... all false!
        Console.WriteLine($"tupleA.Equals(tupleD): {tupleA.Equals(tupleD)}");
        Console.WriteLine($"tupleB.Equals(tupleC): {tupleB.Equals(tupleC)}");
        Console.WriteLine($"tupleA.Equals(tupleF): {tupleA.Equals(tupleF)}");
        Console.WriteLine($"tupleB.Equals(tupleE): {tupleB.Equals(tupleE)}");

        // some interesting notes:
        // - cardinality is required to compile (same number of elements & compatible types)
        // - the names of the elements are not considered in the comparison
        // - the order of the elements IS considered in the comparison
        // - the types do not need to be the same, but they do need to be compatible
    }
}