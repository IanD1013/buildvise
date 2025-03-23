public sealed class Structs
{
    public void RunExample()
    {
        // a struct is a value type, even though it looks like a class!

        // so what is the difference between a struct and a class?
        // why would we make a struct instead of a class?
        // the main difference is that a struct is a value type, and a class is a reference type
        // - A struct is stored on the stack, and a class is stored on the heap
        // - A struct is copied when it is passed to a method, and a class is passed by reference

        // here is an example of a struct being copied when passed to a method:
        void DoSomethingWithPoint(Point p)
        {
            p.X = 111;
            p.Y = 222;
        }

        var ourPoint = new Point()
        {
            X = 123,
            Y = 456
        };
        Console.WriteLine(
            $"ourPoint before DoSomethingWithPoint: " +
            $"{ourPoint.X}, {ourPoint.Y}"); // 123, 456
        DoSomethingWithPoint(ourPoint);
        Console.WriteLine(
            $"ourPoint after DoSomethingWithPoint: " +
            $"{ourPoint.X}, {ourPoint.Y}"); // 123, 456

        // because structs can look like classes, it can be confusing
        // when to use a struct and when to use a class
        // here are some guidelines:
        // - use a struct when you have a small, simple object that
        //   you want to pass by value
        // - use a struct when you want to avoid the overhead of
        //   heap allocation, garbage collecting, etc...
        // I try to think about very primitive things like a Point,
        // or a Color, or a Rectangle, or other geometric things
    }

    // here is an example of a struct
    public struct Point
    {
        public int X;
        public int Y;
    }

    // here is the same struct but with properties:
    public struct PointWithProperties
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // here is the same struct but with a constructor:
    public struct PointWithConstructor
    {
        public PointWithConstructor(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }

    // we can also have a struct with a method, just like with classes:
    public struct PointWithMethod
    {
        public int X;
        public int Y;

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
}