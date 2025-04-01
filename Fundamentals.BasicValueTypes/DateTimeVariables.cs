public sealed class DateTimeVariables
{
    public void RunExample()
    {
        // Date and time can be stored in a DateTime variable
        // Dates can be assigned to a DateOnly variable
        // Times can be assigned to a TimeOnly variable

        // we can declare a DateTime variable
        DateTime myDateTime;

        // we can declare a DateOnly variable
        DateOnly myDate;

        // we can declare a TimeOnly variable
        TimeOnly myTime;


        // We can assign a value to these variables
        myDateTime = DateTime.Now;
        myDate = new DateOnly(2024, 1, 23);
        myTime = new TimeOnly(1, 23, 45);

        // We can declare and assign in one line
        DateTime myDateTime2 = DateTime.Now;
        DateOnly myDate2 = new DateOnly(2024, 1, 23);
        TimeOnly myTime2 = new TimeOnly(1, 23, 45);

        // We can re-assign a value to these variables
        myDateTime = DateTime.Now;
        myDate = new DateOnly(2024, 1, 23);
        myTime = new TimeOnly(1, 23, 45);

        // Dates and times are complex... consider
        // that we haven't factored in time zones!

        // we can make a DateTime variable out of
        // a DateOnly and a TimeOnly variable
        DateTime dateTimeFromCombination = new DateTime(myDate, myTime);

        // Let's write these to the console!
        Console.WriteLine($"Date Only: {myDate}");
        Console.WriteLine($"Time Only: {myTime}");
        Console.WriteLine($"Date Time: {dateTimeFromCombination}");
    }
}