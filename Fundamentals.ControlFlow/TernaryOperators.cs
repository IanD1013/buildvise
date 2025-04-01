public sealed class TernaryOperators
{
    public void RunExample()
    {
        // ternary operators are used to assign a
        // value to a variable based on a condition
        // The syntax is:
        // variable = (condition) ? expressionTrue : expressionFalse;

        int x = 10;
        string result = x > 5
            ? "x is greater than 5"
            : "x is less than 5";
        Console.WriteLine(result);

        result = x == 10
            ? "x is equal to 10"
            : "x is not equal to 10";
        Console.WriteLine(result);

        result = x < 20
            ? "x is less than 20"
            : "x is greater than 20";
        Console.WriteLine(result);
    }
}