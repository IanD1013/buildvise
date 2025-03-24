using CreatingTaskFromScratch;

Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");
DomeTrainTask.Run(() => Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}"));
Console.ReadLine();