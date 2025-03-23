// constructors are used to initialize a class
public sealed class Constructors
{
    public void RunExample()
    {
        OurClassWithAHiddenConstructor instance = new(123);
        Console.ReadLine();
    }

    // this still has a constructor even though we can't see it!
    class ImplicitConstructor
    {
    }

    // this class has a parameterless constructor
    class ExplicitConstructor
    {
        public ExplicitConstructor()
        {
            Console.WriteLine("ExplicitConstructor constructor called");
        }
    }

    // this class has a constructor that takes in a value
    class ConstructorWithParameter
    {
        public ConstructorWithParameter(string message)
        {
            Console.WriteLine(message);
        }
    }

    // this is a class with multiple constructors "chained"
    // together by using : this() syntax
    class MultipleConstructors
    {
        public MultipleConstructors()
            : this("This is the default message!")
        {
        }

        public MultipleConstructors(string message)
        {
            Console.WriteLine(message);
        }
    }

    // generally we use constructors to initialize the class
    class OurCollectionOfWords
    {
        private List<string> _strings;

        public OurCollectionOfWords()
        {
            // we can initialize the list here! this
            // will make it safe for us to use the list
            // later on in the class
            _strings = new List<string>();
        }

        public void Add(string word)
        {
            _strings.Add(word);
        }

        public void Print()
        {
            foreach (var word in _strings)
            {
                Console.WriteLine(word);
            }
        }
    }

    // we can build on the previous example by passing in
    // some words to the constructor
    class OurCollectionOfWords2
    {
        private List<string> _strings;

        public OurCollectionOfWords2(List<string> words)
        {
            _strings = new List<string>();

            foreach (var word in words)
            {
                _strings.Add(word);
            }
        }
        public void Print()
        {
            foreach (var word in _strings)
            {
                Console.WriteLine(word);
            }
        }
    }

    // we can have static constructors which
    // will run the first time the type is used
    class StaticConstructor
    {
        static StaticConstructor()
        {
            Console.WriteLine("StaticConstructor constructor called");
        }
    }

    // we can also have private constructors to prevent
    // certain access patterns for our class
    class OurClassWithAHiddenConstructor
    {
        public OurClassWithAHiddenConstructor(int value)
            : this()
        {
            Console.WriteLine(
                $"This is the public constructor and " +
                $"we received value {value}.");
        }

        private OurClassWithAHiddenConstructor()
        {
            Console.WriteLine(
                "Nobody can call this constructor " +
                "directly from the outside!");
        }
    }
}