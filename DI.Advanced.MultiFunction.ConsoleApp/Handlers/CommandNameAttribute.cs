namespace MultiFunction.ConsoleApp.Handlers;

[AttributeUsage(AttributeTargets.Class)]
public class CommandNameAttribute : Attribute
{
    public string CommandName { get; }

    public CommandNameAttribute(string commandName)
    {
        CommandName = commandName;
    }
}
