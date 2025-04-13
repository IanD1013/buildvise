namespace MultiFunction.ConsoleApp.Console;

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string text)
    {
        System.Console.WriteLine(text);
    }
}
