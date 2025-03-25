using System.Runtime.ExceptionServices;

namespace CreatingTaskFromScratch;

public class DomeTrainTask
{
    private readonly Lock _lock = new();
    private bool _completed; // execution already done, allowing us to return the result instead of deferring execution
    private Exception? _exception; // store exception here if there is one
    private Action? _action; // save that action that user passing into our continue with method
    private ExecutionContext? _context; // all the info required for a logical thread (current process)

    public bool IsCompleted
    {
        get
        {
            lock (_lock)
            {
                return _completed;
            }
        }
    }

    public static DomeTrainTask Delay(TimeSpan delay)
    {
        DomeTrainTask task = new();

        new Timer(_ => task.SetResult()).Change(delay, Timeout.InfiniteTimeSpan);
        
        return task;
    }

    public static DomeTrainTask Run(Action action)
    {
        DomeTrainTask task = new();

        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                action();
                task.SetResult();
            }
            catch (Exception e)
            {
                task.SetException(e);
            }
        });
        
        return task;
    }

    public void Wait()
    {
        ManualResetEventSlim resetEventSlim = null;

        lock (_lock)
        {
            if (!_completed)
            {
                resetEventSlim = new();
                ContinueWith(() => resetEventSlim.Set()); // Set() will allow all the threads waiting on it to proceed
            }
        }
        
        resetEventSlim?.Wait(); // gonna block the current thread until it's allowed to resume

        if (_exception is not null)
        {
            ExceptionDispatchInfo.Throw(_exception);
        }
    }

    public DomeTrainTask ContinueWith(Action action) // (outer task).ContinueWith(inner task)
    {
        DomeTrainTask task = new(); // inner task 

        lock (_lock)
        {
            if (_completed)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        action();
                        task.SetResult();
                    }
                    catch (Exception e)
                    {
                        task.SetException(e);
                    }
                });
            }
            else
            {
                _action = action;
                _context = ExecutionContext.Capture(); // store all info about the outer task
            }
        }
        
        return task;
    }

    public void SetResult() => CompleteTask(null);
    
    public void SetException(Exception exception) => CompleteTask(exception);
    
    private void CompleteTask(Exception? exception)
    {
        lock (_lock)
        {
            if (_completed)
                throw new InvalidOperationException("DomeTrainTask already completed.");
            
            _completed = true;
            _exception = exception;

            if (_action is not null)
            {
                if (_context is null)
                {
                    _action.Invoke();
                }
                else
                {
                    ExecutionContext.Run(_context, state => ((Action)state).Invoke(), _action);
                }
            }
        }
    }
}