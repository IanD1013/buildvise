public sealed class PrimerOnClassesAndValueTypes
{
    public void RunExample()
    {
        // classes are reference types in C#
        // the primitive types (like integers, doubles, and booleans) are value types

        // recall that when we use a reference type, we are passing
        // around a reference to the object in memory

        List<string> ourList = new()
        {
            "Hello",
            "World",
        };

        void DoSomethingWithReference(List<string> list)
        {
            list.Add("From");
            list.Add("Nick");
        }

        Console.WriteLine("Reference Before:");
        foreach (var item in ourList)
        {
            Console.WriteLine(item);
        }

        DoSomethingWithReference(ourList);

        Console.WriteLine("Reference After:");
        foreach (var item in ourList)
        {
            Console.WriteLine(item);
        }
//////////////////////////////////////////////////////////////////////////////
        string ourString = "Hello, World!";
        void DoSomethingWithValue(string value)
        {
            value = "Goodbye, World!";
        }

        Console.WriteLine("Value Before:");
        Console.WriteLine(ourString);

        DoSomethingWithValue(ourString);

        Console.WriteLine("Value After:");
        Console.WriteLine(ourString);
        
//////////////////////////////////////////////////////////////////////////////
        // we can pass a value type by reference using the ref keyword
        void DoSomethingWithValueByRef(ref string value)
        {
            value = "Goodbye, World!";
        }

        Console.WriteLine("Value Before By Ref:");
        Console.WriteLine(ourString);

        DoSomethingWithValueByRef(ref ourString);

        Console.WriteLine("Value After By Ref:");
        Console.WriteLine(ourString);
    }
}