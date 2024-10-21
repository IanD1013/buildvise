// Enums are value types

// We can define an enum like this:
enum DaysOfWeek
{
    Monday, Tuesday, Wednesday, Friday, Saturday, Sunday
}

// We can also define an enum like this:
enum DaysOfWeek2
{
    Monday    = 1,
    Tuesday   = 2,
    Wednesday = 3,
    Thursday  = 4,
    Friday    = 5,
    Saturday  = 6,
    Sunday    = 7
}

// an enum sort of looks like a string in our code because the 
// values of hte enums have names that we can read, but enums
// are in fact numeric values

// we can cast an enum to an int like this:
int monday = (int)DaysOfWeek.Monday;

// this can be confusing because when we write enums to the console
// they look like strings!
Console.WriteLine($"Enum Value Directly: {DaysOfWeek.Monday}");     // Monday
Console.WriteLine($"Enum Value Casted: {(int)DaysOfWeek.Monday}");  // 0

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
    Console.WriteLine($"Enum Value: {day}");
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

// enums can also be used as "flags" which means that we can combine them using
// bitwise operators
[Flags]
enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4
}

// note the [Flags] attribute above and
// the powers of 2 for the values of the enum!

// we can combine the flags like this:
Permissions readWrite = Permissions.Read | Permissions.Write;
Console.WriteLine($"RW: {readWrite}");

// we can check if a flag is set like this:
bool canRead = (readWrite & Permissions.Read) == Permissions.Read;
bool canWrite = (readWrite & Permissions.Write) == Permissions.Write;
Console.WriteLine($"Can Read: {canRead}");
Console.WriteLine($"Can Write: {canWrite}");
