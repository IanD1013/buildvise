public sealed class CreatingClasses
{
    public void RunExample()
    {
        // object oriented programming is a programming paradigm
        // that uses objects and classes in programming
        // we can structure a program by bundling related
        // properties and behaviors into individual objects
        // this means that for the first time we start to think
        // about our programs less like just a series of steps
        // and more like a collection of things that interact!

        // we can create an object from a class by using the new keyword
        OurClass ourObject = new OurClass();

        // we can use the short-form method to create an object
        OurClass ourObject2 = new();

        // let's make a new instance!
        OurSecondClass ourSecondObject = new();
        ourSecondObject.ExampleMethod();

        int result = ourSecondObject.ExampleFunction();

        // where else have we seen classes and objects?
        // the Console class!
        Console.WriteLine("This is a method on the Console class!");

        // Console.WriteLine looks a little bit different...
        // why didn't we have to create a new Console object?
        // we'll see why in a later lesson!
    }

    // in C# we can create a class by using the class keyword
    class OurClass
    {

    }

    // remember the methods and functions we were creating?
    // we can now create methods and functions that are
    // associated with a class!
    public class OurSecondClass
    {
        public void ExampleMethod()
        {
            Console.WriteLine("Hello from our method!");
        }

        public int ExampleFunction()
        {
            return 42;
        }
    }
}
