public sealed class BoleanVariables
{
    public void RunExample()
    {
        // A boolean is a true or false value
        // A boolean in C# is 8 bits or 1 byte

        // We can declare a boolean variable
        bool myBool;
        bool my_bool;
        bool MyBool;

        // We can assign a value to these variables
        myBool = true;
        myBool = false;

        // We can declare and assign in one line
        bool coolBool = true;

        // We can re-assign a value to these variables
        coolBool = false;

        // We can do boolean logic with these variables
        // && is the AND operator
        bool trueAndFalse = true && false;
        bool trueAndTrue = true && true;
        bool falseAndFalse = false && false;

        // || is the OR operator
        bool trueOrFalse = true || false;
        bool trueOrTrue = true || true;
        bool falseOrFalse = false || false;

        // ! is the NOT operator
        bool notTrue = !true;
        bool notFalse = !false;

        // The results of our boolean logic
        // as we see with string interpolation:
        Console.WriteLine($"true && False: {trueAndFalse}");
        Console.WriteLine($"true && True: {trueAndTrue}");
        Console.WriteLine($"false && False: {falseAndFalse}");
        Console.WriteLine($"true || False: {trueOrFalse}");
        Console.WriteLine($"true || True: {trueOrTrue}");
        Console.WriteLine($"false || False: {falseOrFalse}");
        Console.WriteLine($"!True: {notTrue}");
        Console.WriteLine($"!False: {notFalse}");
    }
}