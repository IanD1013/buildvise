using System.Text;

public sealed class ReadingAndWritingFiles
{
    public void RunExample()
    {
        // We can read and write files using built-in classes in C#.

        // There are many convenience methods that we have access to:
        File.WriteAllText("some-file.txt", "Hello, World!");
        File.WriteAllBytes("some-file.txt", Encoding.UTF8.GetBytes("Hello, World! From Nick Cosentino"));
        byte[] someFileBytes = File.ReadAllBytes("some-file.txt");
        string someFileString = File.ReadAllText("some-file.txt");

        // but we can use similar methods to gain access to a stream!
        FileStream fileStream = File.Open(
            "some-file.txt",
            FileMode.OpenOrCreate,
            FileAccess.Write,
            FileShare.Read);
        byte[] buffer = Encoding.UTF8.GetBytes("Hello, World!");
        fileStream.Write(buffer, 0, buffer.Length);

        // but these are the APIs directly on the Stream class!
        Stream fileStreamAsStream = fileStream;
        fileStreamAsStream.Seek(0, SeekOrigin.Begin);
        fileStreamAsStream.Write(buffer, 0, buffer.Length);

        // what do we do when we're all done?
        fileStream.Close();
        // ... but we'll cover a more detailed way to do this properly.
        
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // We can use a very similar API for reading from a file:
        FileStream readingStream = File.Open(
            "some-file.txt",
            FileMode.Open,
            FileAccess.Read,
            FileShare.None);

        // ...but how many bytes do we need if we just want... all of it?
        // we *could* use the Length property of the stream...
        byte[] bufferForReading = new byte[readingStream.Length];
        var bytesReadFromStream = readingStream.Read(
            bufferForReading,
            0,
            bufferForReading.Length);

        // what if the file was huge or we didn't know
        // exactly much much we needed to read in,
        // if not the whole file?
        // if we were interested in reading a text file:
        readingStream.Seek(0, SeekOrigin.Begin);
        StreamReader reader = new StreamReader(
            readingStream,
            encoding: Encoding.UTF8);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            Console.WriteLine(line);
        }

        // you could also write your program to read blocks
        // of bytes from the stream at a time by "chunking"
        // it up and determining when you've read
        // enough!
        int chunkSize = 7; // 1024;
        Console.WriteLine($"Reading chunks of size {chunkSize} of file...");
        readingStream.Seek(0, SeekOrigin.Begin);
        byte[] bufferForChunking = new byte[chunkSize];
        while ((bytesReadFromStream = readingStream.Read(
            bufferForChunking,
            0,
            bufferForChunking.Length)) > 0)
        {
            Console.WriteLine($"Read {bytesReadFromStream} bytes for this chunk!");
        }
    }
}