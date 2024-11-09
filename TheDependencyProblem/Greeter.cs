namespace TheDependencyProblem;

public class Greeter
{
    public string CreateGreetMessage()
    {
        var dateTimeNow = DateTime.Now;
        return dateTimeNow.Hour switch
        {
            >= 5 and < 12 => "Good morning",
            >= 12 and < 18 => "Good afternoon",
            _ => "Good evening"
        };
    }
}
