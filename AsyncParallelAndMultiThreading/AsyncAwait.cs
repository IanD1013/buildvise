public class AsyncAwait
{
    public async Task RunExample()
    {
        // like using Task objects, we can use the async/await keywords to
        // structure async code without having to think about it in terms
        // of objects

        // in order to make an async method, we use a new keyword
        // and the Task object as the return type
        async Task FirstAsyncMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            // write code that is async here!
        }

        // if we need to return anything, we use Task<T>, the generic
        // version, to be able to pass back data:
        async Task<int> SecondAsyncMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return 42;
        }

        // much like the Task objects, we can call these async methods
        // and they'll go off and run... but we should track them!
        // we can use the await keyword to wait for the async method.

        // within our context, we will not run code after the await
        // until the async method has completed.
        Console.WriteLine("awaiting FirstAsyncMethod...");
        await FirstAsyncMethod();

        // alternatively...
        Console.WriteLine("awaiting FirstAsyncMethod again...");
        Task firstAsyncMethodTask = FirstAsyncMethod();
        await firstAsyncMethodTask;

        // like our task examples, we can run several async methods
        async Task<string> ThirdAsyncMethod(TimeSpan timeToWait, string messageToWrite)
        {
            await Task.Delay(timeToWait);
            Console.WriteLine(messageToWrite);

            return messageToWrite;
        }

        Console.WriteLine("Starting 3 async methods...");
        Task<string> task1 = ThirdAsyncMethod(TimeSpan.FromSeconds(1), "Task 1 has completed.");
        Task<string> task2 = ThirdAsyncMethod(TimeSpan.FromSeconds(2), "Task 2 has completed.");
        Task<string> task3 = ThirdAsyncMethod(TimeSpan.FromSeconds(3), "Task 3 has completed.");

        // and we can wait for them all to complete:
        Console.WriteLine("Waiting for 3 async methods...");
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("All 3 async methods have completed.");

        // alternatively, we could wait until any of them completes:
        //Task<string> firstTaskToComplete = await Task.WhenAny(task1, task2, task3);

        // let's look at this interesting behavior to understand
        // that marking something async doesn't just make it
        // automatically run asynchronously
        async Task NotActuallyAsync()
        {
            Console.WriteLine("Entering NotActuallyAsync...");
            Thread.Sleep(1000);
            Console.WriteLine("Exiting NotActuallyAsync...");
        }

        // we can call this method and await it, but it will not
        // actually run asynchronously
        Console.WriteLine("Calling NotActuallyAsync...");
        Task notActuallyAsyncTask = NotActuallyAsync();
        Console.WriteLine("awaiting NotActuallyAsync...");
        await notActuallyAsyncTask;
        Console.WriteLine("Finished awaiting NotActuallyAsync.");

        async Task LeverageTaskYield()
        {
            Console.WriteLine("Entering LeverageTaskYield...");
            await Task.Yield();
            Console.WriteLine("Continuing from LeverageTaskYield...");
            Thread.Sleep(1000);
            Console.WriteLine("Exiting LeverageTaskYield...");
        }

        // we can call this method and await it, and it will
        // at least allow the scheduler to run other tasks
        // thanks to the call to yield
        Console.WriteLine("Calling LeverageTaskYield...");
        Task leverageTaskYieldTask = LeverageTaskYield();
        Console.WriteLine("awaiting LeverageTaskYield...");
        await leverageTaskYieldTask;
        Console.WriteLine("Finished awaiting LeverageTaskYield.");


        // it's important to note that once you introduce async/await
        // into the call tree, you should use it all the way up/down
        // let's look at what happens to our exception handling
        // when you mix async and non-async code
        async Task TestCatchingExceptions()
        {
            // we can await in here because it's marked as async
            Console.WriteLine("TestCatchingExceptions ThisIsNotATask...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished delay inside TestCatchingExceptions...");

            Console.WriteLine("Calling async method...");
            try
            {
                //await ThisIsATask();

                // we *can't* await this because this method is async
                // but does not return a Task.
                //await ThisIsNotATask();
                ThisIsNotATask();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception from async method: {ex.Message}");
            }
        }

        async Task ThisIsATask()
        {
            // we can await in here because it's marked as async
            Console.WriteLine("Entering ThisIsATask...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished delay inside ThisIsATask...");

            throw new Exception("ThisIsATask has thrown an exception!");
        }

        async void ThisIsNotATask()
        {
            // we can await in here because it's marked as async
            Console.WriteLine("Entering ThisIsNotATask...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished delay inside ThisIsNotATask...");

            throw new Exception("ThisIsNotATask has thrown an exception!");
        }

        await TestCatchingExceptions();
    }
}