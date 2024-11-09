namespace AsyncParallelAndMultiThreading;

public class Threads
{
    public void RunExample()
    {
        // Thread objects in C# allow us to create and manage threads.
        Thread thread = new Thread(() => {});
        thread.Start();
        
        // we can also pass parameters to the thread
        ThreadContext thread1Context = new(Name: "Thread 1", Message: "Hello from thread 1!");

        Thread thread1 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;

            Thread.CurrentThread.Name = context.Name;
            Console.WriteLine($"{Thread.CurrentThread.Name}: {context.Message}");
        }));
        thread1.Start(thread1Context);

        // threads can be useful for running work in the background for us
        ThreadContext thread2Context = new(Name: "Thread 2", Message: "Hello from thread 2!");
        Thread thread2 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;
        
            Thread.CurrentThread.Name = context.Name;
        
            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {context.Message}");
                Thread.Sleep(1000);
            }
        }));
        thread2.Start(thread2Context);
        
        // we can also set a thread to be a background thread
        // which will automatically stop when the main thread stops
        ThreadContext thread3Context = new(Name: "Thread 3", Message: "Hello from thread 3!");
        Thread thread3 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;
        
            Thread.CurrentThread.Name = context.Name;
        
            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {context.Message}");
                Thread.Sleep(1000);
            }
        }));
        thread3.IsBackground = true;
        thread3.Start(thread3Context);
        
        Console.WriteLine("Press enter to stop Thread3.");
        Console.ReadLine();
    }

    record ThreadContext(string Name, string Message);
}