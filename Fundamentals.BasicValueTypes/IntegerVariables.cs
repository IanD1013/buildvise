public sealed class IntegerVariables
{
    public void RunExample()
    {
        // Integers are whole numbers
        // An integer in C# is 32 bits or 4 bytes
        // The range of an integer is -2,147,483,648 to 2,147,483,647

        // We can declare an integer variable
        int myInt;
        int my_int;
        int MyInt;

        // We can assign a value to an integer variable
        myInt = -5;

        // We can declare and assign in one line
        int coolInt = 5;

        // We can re-assign a value to an integer variable
        coolInt = 10;

        // We can do math with integers
        int sum = 5 + 10;
        int difference = 5 - 10;
        int product = 5 * 10;
        int quotient = 15 / 10;

        // This is a slightly more advanced but we can see
        // the results of our math with string "interpolation"
        Console.WriteLine($"5 + 10={sum}");
        Console.WriteLine($"5 - 10={difference}");
        Console.WriteLine($"5 * 10={product}");
        Console.WriteLine($"15 / 10={quotient}");

        // Do we notice anything weird about the quotient?
        // Why is it 0?!

        // We'll need to use another type to help us here!
    }
}