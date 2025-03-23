public sealed class ChallengesWithEqualityChecks
{
    public void RunExample()
    {
        // one of the big challenges with value and reference
        // types has to do with checking for equality

        // let's look at class equality
        var myClass1 = new MyClass { NumericValue = 123, StringValue = "ABC" };
        var myClass2 = new MyClass { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myClass1 equal to myClass2:");
        Console.WriteLine(myClass1 == myClass2); // False
        Console.WriteLine(myClass1.Equals(myClass2)); // False
        Console.WriteLine(object.Equals(myClass1, myClass2)); // False

        // let's look at struct equality
        var myStruct1 = new MyStruct { NumericValue = 123, StringValue = "ABC" };
        var myStruct2 = new MyStruct { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myStruct1 equal to myStruct2:");
        //Console.WriteLine(myStruct1 == myStruct2); // does not compile
        Console.WriteLine(myStruct1.Equals(myStruct2)); // True
        Console.WriteLine(object.Equals(myStruct1, myStruct2)); // True

        // how does this one shape up??

        var myClassWithEquality1 = new MyClassWithEquality { NumericValue = 123, StringValue = "ABC" };
        var myClassWithEquality2 = new MyClassWithEquality { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myClassWithEquality1 equal to myClassWithEquality2:");
        Console.WriteLine(myClassWithEquality1 == myClassWithEquality2); // False
        Console.WriteLine(myClassWithEquality1.Equals(myClassWithEquality2)); // True
        Console.WriteLine(object.Equals(myClassWithEquality1, myClassWithEquality2)); // True

        // does this fix our issue?
        var myClassWithEqualityAndOperator1 = new MyClassWithEqualityAndOperator { NumericValue = 123, StringValue = "ABC" };
        var myClassWithEqualityAndOperator2 = new MyClassWithEqualityAndOperator { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myClassWithEqualityAndOperator1 equal to myClassWithEqualityAndOperator2:");
        Console.WriteLine(myClassWithEqualityAndOperator1 == myClassWithEqualityAndOperator2); // True
        Console.WriteLine(myClassWithEqualityAndOperator1.Equals(myClassWithEqualityAndOperator2)); // True
        Console.WriteLine(object.Equals(myClassWithEqualityAndOperator1, myClassWithEqualityAndOperator2)); // True

        // we can see that this gets really complicated really quickly
        // and this just comes back to the fundamental difference between
        // value and reference types.
        // trying to change the behavior of a reference type for equality
        // is very error prone - and we only looked at a class that
        // had two basic value types!
    }


    public class MyClass
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }
    }

    public struct MyStruct
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }
    }

    // people then try to fix the class equality by overriding the Equals method
    public class MyClassWithEquality
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (MyClassWithEquality)obj;
            return NumericValue == other.NumericValue && StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
        }
    }

    // the problem is that the == operator is not overridden
    // and the default implementation is used. let's fix it.
    public class MyClassWithEqualityAndOperator
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (MyClassWithEqualityAndOperator)obj;
            return NumericValue == other.NumericValue && StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
        }

        public static bool operator ==(MyClassWithEqualityAndOperator left, MyClassWithEqualityAndOperator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MyClassWithEqualityAndOperator left, MyClassWithEqualityAndOperator right)
        {
            return !left.Equals(right);
        }
    }
}