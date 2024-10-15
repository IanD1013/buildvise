/** WHILE LOOPS **/
int count = 0;
while (count < 5)
{
    Console.WriteLine(count);
    count++;
}

// do-while loop
count = 0;
do
{
    Console.WriteLine(count);
    count++;
} while (count < 5);

// break and continue
count = 0;
while (count < 5)
{
    if (count == 3)
    {
        count++;
        Console.WriteLine("I'm skipping 3!");
        continue;
    }

    Console.WriteLine(count);
    count++;

    if (count == 4)
    {
        Console.WriteLine("I'm out of here!");
        break;
    }
}

/** FOR LOOPS **/
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

/** FOR-EACH LOOPS **/
// an array
int[] numbers = { 1, 2, 3, 4, 5 };
foreach (int number in numbers)
{
    Console.WriteLine(number);
}

// a list of strings
List<string> words = new List<string> { "red", "green", "blue" };
foreach (string word in words)
{
    Console.WriteLine(word);
}

// a dictionary?
Dictionary<string, int> ages = new()
{
    { "Alice", 25 },
    { "Bob", 24 },
    { "Charlie", 26 },
};

//foreach (KeyValuePair<string, int> person in ages)
foreach (var person in ages)
{
    Console.WriteLine($"{person.Key} is {person.Value} years old");
}
