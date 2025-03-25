using CreatingTaskFromScratch;

Console.WriteLine($"Starting Thread Id: {Environment.CurrentManagedThreadId}");

DomeTrainTask.Run(() => Console.WriteLine($"First DomeTrainTask Id: {Environment.CurrentManagedThreadId}")).Wait();

DomeTrainTask.Delay(TimeSpan.FromSeconds(1)).Wait();

Console.WriteLine($"Second DomeTrainTask Id: {Environment.CurrentManagedThreadId}");

DomeTrainTask.Delay(TimeSpan.FromSeconds(1)).Wait();

DomeTrainTask.Run(() => Console.WriteLine($"Third DomeTrainTask Id: {Environment.CurrentManagedThreadId}")).Wait();

