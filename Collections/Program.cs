/** ARRAYS **/
int[] numbers = new int[3];
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;

// declare and initialize an array
int[] numbers2 = new int[] { 5, 6, 7, 8 };
int[] numbers3 = { 5, 6, 7, 8 };
int[] numbers4 = [5, 6, 7, 8];

int length = numbers.Length;

/** LISTS **/
List<string> words = new List<string>();
List<string> lines = new();

// here is how we add values to a list
words.Add("one");
words.Add("two");
words.Add("three");

// here is how we get values from a list
string firstWord = words[0];
string secondWord = words[1];
string thirdWord = words[2];

words[0] = "four";

// here is how we declare and initialize a list
List<int> nums = new List<int> { 1, 2, 3, 4 };

// here is how we get the count of a list
int count = nums.Count;

// here is how we remove a value from a list
nums.Remove(1);

// here is how we insert a value into a list
nums.Insert(0, 1);

// here is how we clear a list
nums.Clear();

// here is how we sort a list
words.Sort();


/** DICTIONARY **/
// here is how we declare a dictionary
Dictionary<string, int> wordsToNumbers = new Dictionary<string, int>();
Dictionary<int, string> numbersToWords = new Dictionary<int, string>();
Dictionary<string, int> shorthand = new();

// here is how we add entries into a dictionary
wordsToNumbers.Add("one", 1);
wordsToNumbers.Add("two", 2);
wordsToNumbers.Add("three", 3);

// here is what this will look like as we go line by line:
// ["one"] = 1
// ["two"] = 2
// ["three"] = 3

// here is how we get values from a dictionary
int one = wordsToNumbers["one"];
int two = wordsToNumbers["two"];
int three = wordsToNumbers["three"];

// here is how we set values in a dictionary
wordsToNumbers["one"] = 111;
wordsToNumbers["two"] = 222;

// wordsToNumbers is now:
// ["one"] = 111
// ["two"] = 222
// ["three"] = 3

// here is how we declare and initialize a dictionary
Dictionary<int, string> numbersToWords2 = new Dictionary<int, string>
{
    { 1, "one" },
    { 2, "two" },
    { 3, "three" },
    { 4, "four" }
};

Dictionary<int, string> numbersToWords3 = new Dictionary<int, string>
{
    [1] = "one",
    [2] = "two",
    [3] = "three",
    [4] = "four"
};

Dictionary<int, string> numbersToWords4 = new()
{
    [1] = "one",
    [2] = "two",
    [3] = "three",
    [4] = "four"
};

// here is how we get the count of a dictionary
int cnt = numbersToWords2.Count; // 4

// numbersToWords2 is:
// [1] = "one"
// [2] = "two"
// [3] = "three"
// [4] = "four"

// here is how we remove a value from a dictionary
numbersToWords2.Remove(1);
numbersToWords2.Remove(2);

// numbersToWords2 is now:
// [3] = "three"
// [4] = "four"

// here is how we clear a dictionary
numbersToWords3.Clear();
numbersToWords4.Clear();

// here is how we check if a dictionary contains a key
bool contains = numbersToWords2.ContainsKey(3); // true

// here is how we check and get a value from a dictionary
bool contains2 = numbersToWords2.TryGetValue(
    3,
    out string? value
);

// what happens if we add something that already exists?
// ERROR!
// wordsToNumbers.Add("one", 1);
// numbersToWords2.Add(1, "one");

// we can use the indexer to add or set values
// which will overwrite existing values
wordsToNumbers["one"] = 1;
numbersToWords2[1] = "one";
