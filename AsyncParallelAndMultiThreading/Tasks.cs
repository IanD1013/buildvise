public class Tasks
{
    public void RunExample()
    {
        // Tasks in C# allow us to perform asynchronous operations.
        // Using Task objects, we can get more control over
        // how we'd like our asynchronous operations to be executed.

        // Let's run some tasks and see which threads they are executed on:
        Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}");

        Task task1 = Task.Run(() =>
        {
            Console.WriteLine($"Task 1 Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        });

        Task task2 = Task.Run(() =>
        {
            Console.WriteLine($"Task 2 Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        });

        Task task3 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Task 3 Thread Id: {Thread.CurrentThread.ManagedThreadId} ({i})");
                Thread.Sleep(1000);
            }
        });
        
        // something is weird with this output! why did task3
        // not perform its iterations as we'd expect?
        
        // we should wait for the tasks to complete
        // before allowing continued execution:
        Task.WaitAll(task1, task2, task3);
        Console.WriteLine("Tasks 1, 2, and 3 have completed.");
        
        // we can even wait for all three tasks to complete
        // before we start a 4th task, which we will also wait on
        Task task4 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task 4 Thread Id: {Thread.CurrentThread.ManagedThreadId} ({i})");
                Thread.Sleep(500);
            }
        });
        task4.Wait();
        Console.WriteLine("Task 4 has completed.");
        
        
        // we can also use the "builder pattern" to chain things together
        // on task objects:
        Task task5 = Task.Run(() =>
        {
            Console.WriteLine($"Task 5 Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 5 Continuation Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        });
        task5.Wait();
        

        /*
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 5 Continuation Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            throw new Exception("We intended to do this!");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 5 Continuation 2 Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"{prevTask.Exception.GetType().Name}: {prevTask.Exception.Message}");
        }, TaskContinuationOptions.OnlyOnFaulted);
        */

        
        // aggregate exceptions are a way to handle multiple exceptions
        // that can occur when working with tasks
        AggregateException aggregateException = new(
            "This is the aggregate exception message.",
            new InvalidOperationException("This is the first inner exception."),
            new ArgumentException("This is the second inner exception."));

        try
        {
            throw aggregateException;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            foreach (Exception innerEx in ex.InnerExceptions)
            {
                Console.WriteLine($"\t{innerEx.GetType().Name}: {innerEx.Message}");
            }
        }
        
    }
}