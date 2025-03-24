public class CancellationTokens
{
    public async Task RunExample()
    {
        // we can use cancellation tokens with our async/await code
        // to cancel tasks that are running:

        // we can get a token from a CancellationTokenSource:
        CancellationTokenSource cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;

        async Task LoopUntilCancelledAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();
            Console.WriteLine("Looping until cancelled...");

            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Waiting...");

                // await Task.Delay(3000, cancellationToken);
                
                try
                {
                    await Task.Delay(3000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                
            }

            Console.WriteLine("Cancelled.");
        }

        Console.WriteLine("Press enter to cancel the loop.");
        Task loopTask = LoopUntilCancelledAsync(cancellationToken);

        Console.ReadLine();
        cts.Cancel();

        await loopTask;

        
        // we can chain cancellation tokens together:
        CancellationTokenSource cts2 = new CancellationTokenSource();
        var cancellationToken2 = cts2.Token;
        var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken2);
        var linkedToken = linkedTokenSource.Token;

        Console.WriteLine("Using a linked token source!");
        Console.WriteLine("Press enter to cancel the loop.");
        loopTask = LoopUntilCancelledAsync(linkedToken);
 
        Console.ReadLine();
        cts2.Cancel();

        await loopTask;
        
    }
}