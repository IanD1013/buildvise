internal class Records
{
    public void RunExample()
    {
        // records were introduced in C# 9 and aim to help with
        // the equality problem, especially for simple situations
        // where we have "data transfer objects" or "DTOs"
        // a record is a reference type, but it has value semantics



        // note that the init keyword is used to make the properties
        // immutable. we can still use the object initializer syntax
        // to create the record though:
        MyRecord myRecord1 = new(123, "ABC");
        MyRecord2 myRecord2 = new()
        {
            NumericValue = 123,
            StringValue = "ABC"
        };

        // but note that in both cases, we cannot change the properties
        // because they are both "init" only:
        //myRecord1.NumericValue = 456; // does not compile
        //myRecord2.NumericValue = 456; // does not compile

        //// so how does the equality work?
        MyRecord recordA = new(123, "ABC");
        MyRecord recordB = new(123, "ABC");
        //Console.WriteLine("recordA equal to recordB:");
        //Console.WriteLine(recordA == recordB); // True
        //Console.WriteLine(recordA.Equals(recordB)); // True
        //Console.WriteLine(object.Equals(recordA, recordB)); // True

        //// we can also use the "with" keyword to create a new record
        //// with the same values as the original, but with some changes!
        MyRecord recordC = recordA with { NumericValue = 456 };

        //// let's print this to the console and see what these look like:
        //Console.WriteLine(recordA); // MyRecord { NumericValue = 123, StringValue = ABC }
        //Console.WriteLine(recordB); // MyRecord { NumericValue = 123, StringValue = ABC }
        //Console.WriteLine(recordC); // MyRecord { NumericValue = 456, StringValue = ABC }

        // woah! records have a really nice ToString() implementation!
        
//////////////////////////////////////////////////////////////////////////////////////////////////////////
        // we can deconstruct the record into its properties:
        var (numericValue, stringValue) = recordA;

        // notice that it's positional based on the order of the properties
        // so this won't work:
        //(string stringValue2, int numericValue2) = recordA; // does not compile!

        // records can also be defined as structs, which means they'll
        // go on the stack instead of the heap. this can be useful for
        // performance reasons, especially if we have a lot of them.
        //public record struct MyRecordStruct(
        //    int NumericValue,
        //    string StringValue);

        MyRecordWithExtraProperties recordWithExtraProperties = new(123, "ABC")
        {
            ExtraProperty = "DEF"
        };
        Console.WriteLine("recordWithExtraProperties.ExtraProperty (before):");
        Console.WriteLine(recordWithExtraProperties.ExtraProperty); // DEF
        recordWithExtraProperties.ExtraProperty = "AAA BBB CCC";
        Console.WriteLine("recordWithExtraProperties.ExtraProperty (after):");
        Console.WriteLine(recordWithExtraProperties.ExtraProperty); // AAA BBB CCC
    }

    public record MyRecord(
    int NumericValue,
    string StringValue);

    // notice how we don't need to define the properties?! They
    // are automatically created for us. we could do it manually
    // though if we wanted to:
    public record MyRecord2
    {
        public int NumericValue { get; init; }
        public string StringValue { get; init; }
    }

    // if needed, we can mix in things like additional properties
    // that aren't just from the positional ones on the constructor
    public record MyRecordWithExtraProperties(
        int NumericValue,
        string StringValue)
    {
        public string ExtraProperty { get; set; }
    }
}