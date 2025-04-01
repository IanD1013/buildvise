public sealed class FloatAndDoubleVariables
{
    public void RunExample()
    {
        // Floating point numbers are numbers with a decimal point
        // A float in C# is 32 bits or 4 bytes
        // The range of a float is 1.5 x 10^-45 to 3.4 x 10^38
        // A double in C# is 64 bits or 8 bytes
        // The range of a double is 5.0 x 10^-324 to 1.7 x 10^308

        // We can declare a float variable
        float myFloat;
        float my_float;
        float MyFloat;

        // We can declare a double variable
        double myDouble;
        double my_double;
        double MyDouble;

        // We can assign a value to these variables
        myFloat = 5.5f;
        myDouble = 5.5d;

        // We can declare and assign in one line
        float coolFloat = 5.5f;
        double coolDouble = 5.5;

        // We can re-assign a value to these variables
        coolFloat = 10.5f;
        coolDouble = 10.5;

        // We can do math with these numbers
        float sum = 5.5f + 10.5f;
        float difference = 5.5f - 10.5f;
        float product = 5.5f * 10.5f;
        float quotient = 15.5f / 10.5f;

        // (the same thing for doubles)

        // The results of our math with string "interpolation"
        Console.WriteLine($"5.5 + 10.5={sum}");
        Console.WriteLine($"5.5 - 10.5={difference}");
        Console.WriteLine($"5.5 * 10.5={product}");
        Console.WriteLine($"15.5 / 10.5={quotient}");

        // Much better for decimals!
    }
}