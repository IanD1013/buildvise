public sealed class SwitchStatementAndExpression
{
    public void RunExample()
    {
        // The switch statement is used to select one of
        // many code blocks to be executed.
        // The switch expression is used to select one of
        // many code blocks to be executed.

        // here is an example of a switch statement
        int dayOfWeek = 4;
        switch (dayOfWeek)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                Console.WriteLine("Week Day");
                break;
            case 6:
            case 7:
                Console.WriteLine("Weekend");
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }

        Console.WriteLine("This is after the switch!");

        // here is an example of a switch expression
        string dayOfWeekName = "Haha";
        string result = dayOfWeekName switch
        {
            "Monday" => "First day of the week",
            "Tuesday" => "Second day of the week",
            "Wednesday" => "Third day of the week",
            "Thursday" => "Fourth day of the week",
            "Friday" => "Fifth day of the week",
            "Saturday" => "Sixth day of the week",
            "Sunday" => "Seventh day of the week",
            _ => "Invalid day"
        };
    }
}