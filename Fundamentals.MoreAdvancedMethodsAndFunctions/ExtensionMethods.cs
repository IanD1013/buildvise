// The requirements are:
// - We need a static class
// - We need a static method on the class
// - We need the "this" keyword on the parameter that we are "extending"
// - The parameter marked with "this" must be the first parameter
public static class Extensions
{
    public static string Reverse(this string str)
    {
        var reversedChars = str
            .Reverse<char>()
            .ToArray();
        var reversed = new string(reversedChars);
        return reversed;
    }
}

public sealed class ExtensionMethods
{
    public void RunExample()
    {
        // extension methods in C# allow us to add new methods
        // to existing types without modifying the original type
        // or creating a new derived type

        // extension methods are a special kind of static method
        // but they look like instance methods!



        // the name of this class ONLY matters if your goal
        // is to call it the traditional static method call way
        var reversedStr = Extensions.Reverse("Hello World");

        // but when we call it like an extension method
        // we get this really cool syntax where it looks
        // like Reverse() is a method that's built
        // into the string class!
        var forwardStr = reversedStr.Reverse();

        // there's a popular part of dotnet that uses extension methods
        // called LINQ (Language Integrated Query)!

        IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // nearly all of the methods we see in intellisense
        // when accessing numbers are extension methods
        // from LINQ!
        var evenNumbers = numbers.Where(n => n % 2 == 0);
    }
}