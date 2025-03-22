public sealed class ReferenceType
{
    public void RunExample()
    {
        // objects are "reference types" in C#
        // and up until now we've only been working with
        // "value types" like int, double, and bool
        // ... except for our collections!

        OurClass object1 = new OurClass(); // new reference
        OurClass object2 = new OurClass(); // new reference
        OurClass object3 = object1; // same reference as object1!

        Console.WriteLine("object1 == object2:");
        Console.WriteLine(object1 == object2); // false
        Console.WriteLine("object1 == object3:");
        Console.WriteLine(object1 == object3); // true

        // collections are very much the same!
        List<int> myNumbers1 = new List<int> { 1, 2, 3 };
        List<int> myNumbers2 = new List<int> { 1, 2, 3 };

        Console.WriteLine("myNumbers1 == myNumbers2:");
        Console.WriteLine(myNumbers1 == myNumbers2); // false

        // let's wrap up with re-examining parameter passing
        // with value types and reference types!
        void ChangeValue(int value)
        {
            value = 42;
        }

        int myValue = 1337;
        Console.WriteLine("myValue before ChangeValue:");
        Console.WriteLine(myValue); // 1337
        ChangeValue(myValue);
        Console.WriteLine("myValue after ChangeValue:");
        Console.WriteLine(myValue); // 1337

        void ChangeReference(List<string> words)
        {
            words = new List<string>();
            words.Add("from");
            words.Add("Dev");
            words.Add("Leader");
        }

        List<string> myWords = new List<string> { "Hello", "World" };
        Console.WriteLine("myWords before ChangeReference:");
        Console.WriteLine(string.Join(" ", myWords)); // Hello World
        ChangeReference(myWords);
        Console.WriteLine("myWords after ChangeReference:");
        Console.WriteLine(string.Join(" ", myWords)); // Hello World from Dev Leader

        // this is because when we pass a value type to a method
        // we're passing a copy of the value but when we pass a
        // reference type to a method we're passing the reference!
    }

    // in C# we can create a class by using the class keyword
    class OurClass
    {

    }
}