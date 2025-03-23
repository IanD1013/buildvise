public sealed class Enums
{
    public void RunExample()
    {
        // enums are value types
        // ... they look like strings AND numbers
        // but which are they?! let's dive in and see...

        // disclaimer: I highly recommend that you reserve the use of enums for
        // when you have a fixed set of values that you know will never change
        // ... this isn't a "rule" but it's a good practice

        // an enum sort of looks like a string in our code because
        // the values of the enums have names that we can read,
        // but enums are in fact numeric values

        // we can cast an enum to an int like this:
        int monday = (int)DaysOfWeek.Monday;

        // we cannot cast an enum to a string:
        //string monday = (string)DaysOfWeek.Monday; // this will not compile

        // this can be confusing because when we write enums to the console
        // they look like strings!
        Console.WriteLine($"Enum Value Directly: {DaysOfWeek.Monday}");    // Monday
        Console.WriteLine($"Enum Value Casted: {(int)DaysOfWeek.Monday}"); // 0

        // this means that if we want to go from an enum to a string
        // we need to use the ToString() method
        string mondayString = DaysOfWeek.Monday.ToString();

        // and if we want to go from a string to an enum
        // we need to use the Enum.Parse method
        DaysOfWeek mondayEnum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Monday");
        DaysOfWeek mondayEnum2 = Enum.Parse<DaysOfWeek>("Monday");

        // there is a TryParse variation as well:
        DaysOfWeek mondayEnum3;
        bool parseSucceeded = Enum.TryParse("Monday", out mondayEnum3);
        Console.WriteLine($"Enum {(parseSucceeded ? "Was Parsed" : "Was Not Parsed")}: {mondayEnum3}");

        // we can also use the Enum.GetValues method to get all the values of an enum
        Console.WriteLine("All Enum Values:");
        foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"Enum Value: {(int)day}");
        }

        // we can also use the Enum.GetNames method to get all the names of an enum
        Console.WriteLine("All Enum Names:");
        foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"Enum Name: {day}");
        }

        // there's a weird behavior where we can technically cast an int to an enum
        // even if the int doesn't correspond to a valid enum value!
        DaysOfWeek invalidDay = (DaysOfWeek)8;
        Console.WriteLine($"Invalid Enum Value: {invalidDay}");

        // note the [Flags] attribute above and
        // the powers of 2 for the values of the enum!

        // we can combine the flags like this:
        Permissions readWrite = Permissions.Read | Permissions.Write;
        Console.WriteLine($"RW: {readWrite}");

        // we can check if a flag is set like this:
        bool canRead = (readWrite & Permissions.Read) == Permissions.Read;
        bool canWrite = (readWrite & Permissions.Write) == Permissions.Write;
        bool canExecute = (readWrite & Permissions.Execute) == Permissions.Execute;
        Console.WriteLine($"Can Read: {canRead}");
        Console.WriteLine($"Can Write: {canWrite}");
        Console.WriteLine($"Can Execute: {canExecute}");
    }

    // we can define an enum like this:
    enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    // we can also define an enum like this:
    enum DaysOfWeek2
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    // enums can also be used as "flags" which means that we can combine them
    // using bitwise operators
    [Flags]
    enum Permissions
    {
        None = 0,    // 0000 0000
        Read = 1,    // 0000 0001
        Write = 2,    // 0000 0010
        Execute = 4     // 0000 0100
    }
}