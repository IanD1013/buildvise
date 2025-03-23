using System.ComponentModel;

public class BackgroundWorkers
{
    public void RunExample()
    {
        // we can use a BackgroundWorker to run a method in the background
        // and historically this was used a lot in WinForms applications

        // here's how we'd create a new BackgroundWorker
        BackgroundWorker worker1 = new BackgroundWorker();

        // we can then subscribe to the DoWork event
        worker1.DoWork += (sender, e) =>
        {
            // all of this code is what's run in the background
            while (true)
            {
                Console.WriteLine("Worker 1: Working in the background...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Worker 1: DoWork has completed.");
        };
        worker1.RunWorkerAsync();

        /*
        // like with threads, we can pass parameters into the background worker
        // when we start it
        BackgroundWorker worker2 = new BackgroundWorker();
        worker2.DoWork += (sender, e) =>
        {
            int iterations = (int)e.Argument;
            for (int i = 0; i < iterations; i++)
            {
                Console.WriteLine($"Worker 2: Working in the background on iteration {i}...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Worker 2: DoWork has completed.");
        };
        worker2.RunWorkerAsync(5);
        */

        /*
        // we can also subscribe to the RunWorkerCompleted event
        worker2.RunWorkerCompleted += (sender, e) =>
        {
            Console.WriteLine("Background Worker 2 has completed.");
        };
        */

        /*
        // we can cancel the background worker too! let's modify
        // worker2 to cancel worker1 when it finishes.
        worker2.RunWorkerCompleted += (sender, e) =>
        {
            Console.WriteLine("Background Worker 2 has completed.");
            worker1.CancelAsync();
        };
        */

        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
    }
}