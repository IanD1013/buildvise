using System.Text;

public sealed class StreamIntroduction
{
    public void RunExample()
    {
        // Streams in C# allow us to work with data
        // in a more abstract way than just having
        // a byte array.
        // Streams provide us a common API for working
        // with binary data without having to know
        // exactly how that data is represented
        // behind the scenes!

        // Remember inheritance? There is a base class
        // for all streams called Stream, which is abstract.
        // Stream stream = new Stream(); // won't compile!

        // Streams provide information about the data source
        // that we're working with, like:
        // - the length of the data
        // - the current position in the data
        // - whether we can read from or write to the data
        // It's important to note that all streams get
        // these properties/methods because they inherit
        // from the base... but not all of them support
        // all of the functionality!

        // let's start with one of the most basic streams,
        // the MemoryStream

        MemoryStream memoryStream = new MemoryStream();

        // we can write data to a memory stream
        Console.WriteLine("Writing data to memory stream...");
        Console.WriteLine($"Stream Position Before: {memoryStream.Position}");
        Console.WriteLine($"  Stream Length Before: {memoryStream.Length}");
        Console.WriteLine($"Stream Capacity Before: {memoryStream.Capacity}");

        byte[] data = Encoding.UTF8.GetBytes("Hello, World! From Nick Cosentino");
        memoryStream.Write(data, 0, data.Length);

        Console.WriteLine($"Stream Position After: {memoryStream.Position}");
        Console.WriteLine($"  Stream Length After: {memoryStream.Length}");
        Console.WriteLine($"Stream Capacity After: {memoryStream.Capacity}");
        Console.WriteLine();

        // if we wanted to read the data back out of the stream,
        // it's important to note the position we're currently in now

        // let's get back to the start using "Seek", which allows
        // us to specify where we're seeking relative to
        Console.WriteLine("Repositioning memory stream...");
        memoryStream.Seek(0, SeekOrigin.Begin);
        // or
        memoryStream.Position = 0;
        Console.WriteLine($"Stream Position After: {memoryStream.Position}");

        // now we can read our data back out!
        // ... but how much data do we need to read?
        // ... where are we putting it?

        byte[] readBuffer = new byte[memoryStream.Length];

        Console.WriteLine("Reading data from memory stream...");
        int numberOfBytesRead = memoryStream.Read(readBuffer, 0, readBuffer.Length);
        Console.WriteLine($"Number of bytes read: {numberOfBytesRead}");

        string readString = Encoding.UTF8.GetString(readBuffer);
        Console.WriteLine($"Read string: {readString}");
        Console.WriteLine();

        // also important to note that MemoryStream
        // has a little "shortcut" for getting the bytes:
        Console.WriteLine("Reading data from memory stream using ToArray()...");
        byte[] memoryStreamBytes = memoryStream.ToArray();
        readString = Encoding.UTF8.GetString(memoryStreamBytes);
        Console.WriteLine($"Read string: {readString}");
    }
}