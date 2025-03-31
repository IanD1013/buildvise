public sealed class DisposableAndUsing
{
    public void RunExample()
    {
        // when we're working with resources, there's a common pattern
        // that we have available for indicating when we have
        // things that need to be released and when we're done
        // using them.

        // recall that we had File.Open that returned a FileStream
        // ... but when we're using that stream, it's possible
        // that others aren't allowed to have the access that
        // they want to it
        Stream readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);

        // TODO: do work!

        readmeStream.Dispose();

        // but what if something goes wrong when we're "doing work"?
        // we *NEED* to make sure we properly release our resources,
        // so we could do something like...
        readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
        try
        {
            // TODO: do work!
        }
        catch
        {
            // TODO: handle the exception
        }
        finally
        {
            readmeStream.Dispose();
        }

        // That'll do the trick! But... it's kind of gross because it means
        // that we have to wrap everything in an whole try/catch/finally
        // and it's also an entire extra level of indentation

        // We also have... the "using" statement!
        using (Stream myUsingStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read))
        {
            // TODO: do work!
        }

        // This has the same behavior as we just looked at,
        // but it's arguable a lot easier to read and understand
        // it also ensures that we can have a variable defined
        // just for the scope of the block, where you'll notice
        // the try/catch we had to pull it out the front

        // BUT... we have one more nice addition!

        using Stream myUsingStream2 = File.Open("readme.txt", FileMode.Open, FileAccess.Read);

        // This is a feature from C# 8.0 that allows us to use
        // the "using" statement without the block!
        // - no indentation or curly braces
        // - same functionality
        // - ... but maybe less obvious when it will dispose?
        // the answer to that is that it will dispose as soon as the
        // variable goes out of scope.
        // if you want more tight control, the previous way
        // may be better.
    }

    // IDisposable is the interface we're provided with that
    // allows us to indicate that we have resources that need
    // to be released.
    public class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            // TODO: release resources that are owned by this object
        }
    }
}