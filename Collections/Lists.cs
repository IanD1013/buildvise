public sealed class Lists
{
    public void RunExample()
    {
        // lists are used to store multiple values 
        // - lists are zero based
        // - lists are dynamic in size
        // - we can get values from a list
        // - we can set values in a list
        // - we can add values to a list
        // - we can remove values from a list
        // - we can insert values into a list
        // - we can clear a list
        // - we can sort a list!

        // here is how we declare a list
        List<string> words = new List<string>();

        // here is how we add values to a list
        words.Add("one");
        words.Add("two");
        words.Add("three");

        // here is how we get values from a list
        string firstWord = words[0];
        string secondWord = words[1];
        string thirdWord = words[2];

        words[0] = "four";
        // words is now:
        // ["four"]
        // ["two"]
        // ["three"]
        // after sorting:
        // ["four"]
        // ["three"]
        // ["two"]

        // here is how we declare and initialize a list
        List<int> numbers = new List<int>
        {
            1,
            2,
            3,
            4,
        };

        // here is how we get the count of a list
        int count = numbers.Count; //4

        // here is how we remove a value from a list
        numbers.Remove(1);
        numbers.Remove(2);
        numbers.Remove(3);

        // numbers is now:
        // [2]
        // [3]
        // [1]
        // [4]

        // here is how we insert a value into a list
        numbers.Insert(0, 1);
        numbers.Insert(0, 2);
        numbers.Insert(1, 3);

        // here is how we clear a list
        numbers.Clear();

        // here is how we sort a list
        words.Sort();
    }
}