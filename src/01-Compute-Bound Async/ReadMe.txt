Compute-Bound Async ReadMe

Part A: Threading Basics

1. Add a DoWork method which loops a specified number of times,
   doing work by putting the thread to sleep.
   - Print out the thread id and whether it is a thread pool thread
   - Prompt for number of times to interate

    static int DoWork(object arg)
    {
        string threadName = Thread.CurrentThread.IsThreadPoolThread
            ? "Thread Pool Thread"
            : Thread.CurrentThread.Name;
        int max = (int)arg;

        int result = 1;
        for (int i = 0; i < max; i++)
        {
            Console.WriteLine("{0} working {1} ...", threadName, i + 1);
            Thread.Sleep(100);
            result++;
        }
        return result;
    }

2. Prompt for number of times to iterate and call method with each iteration
   - Name the main thread to see it printed to the console

    private static void UseMainThread()
    {
        // Synchronous invocation
        Thread.CurrentThread.Name = "Main Thread";

        const int units = 5;
        Console.WriteLine("Number of workers:");
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            int result = DoWork(units);
            Console.WriteLine("{0} completed: {1}", "Main Thread", result);
        }
    }

	- Run the program to see the work executed synchronously

3. Next write code to create a thread manually for performing work asynchronously
   - This is for either a long-running operation, or when there is a need to 
     change the property of a thread (for example, name, priority, interop, etc).

    private static void UseManualThread()
    {
        // Manual threads:
        // - long running operation
        // - changing a property of the thread (interop, priority, etc)

        const int units = 5;
        Console.WriteLine("Number of workers:");
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            var workerName = string.Format("Worker Thread {0}", i + 1);
            var worker = new Thread(u =>
            {
                int result = DoWork(u);
                Console.WriteLine("{0} completed: {1}", workerName, result);
            });
            worker.Name = workerName;
            worker.Start(units);
        }
    }

4. Add a completion callback method following the Async Programming Model
   - Obtain the worker name from the async state
   - Obtain the worker delegate from the async delegate

    static void WorkCompleted(IAsyncResult ar)
    {
        var workerName = (string)ar.AsyncState;
        var worker = (Func<object, int>) ((AsyncResult) ar).AsyncDelegate;
        int result = worker.EndInvoke(ar);
        Console.WriteLine("{0} completed: {1}", workerName, result);
    }

5. Add a method to use pooled threads with delegates
   - Because thread pools threads are background threads, they do not prevent
     the application from exiting, so we need to use a WaitHandle to block
	 until all threads have finished executing.
   - Pass workerName to the as the last parameter as async state

    private static void UseAsyncDelegates()
    {
        // Pooled threads using delegates:
        // - short running operation
        // - no need to change a property of the thread

        const int units = 5;
        Console.WriteLine("Number of workers:");
        int count = int.Parse(Console.ReadLine());
        var waits = new WaitHandle[count];
        for (int i = 0; i < count; i++)
        {
            var workerName = string.Format("Worker Thread {0}", i + 1);
            Func<object, int> worker = DoWork;
            waits[i] = worker.BeginInvoke(units, WorkCompleted, workerName).AsyncWaitHandle;
        }
        WaitHandle.WaitAll(waits);
    }

6. Add a method to use tasks
   - Task array needed for blocking until all tasks have completed
   - Handles target method with Func<object, T> signature

    private static void UseTasks()
    {
        // Pooled threads using tasks:
        // - async return values better with Funcs
        // - continuation callbacks are cleaner as lambda
        // - captures local variables

        const int units = 5;
        Console.WriteLine("Number of workers:");

        int count = int.Parse(Console.ReadLine());
        var tasks = new Task[count];

        for (int i = 0; i < count; i++)
        {
            var workerName = string.Format("Worker Thread {0}", i + 1);
            var task = new Task<int>(DoWork, units);
            tasks[i] = task;

            task.ContinueWith(t =>
            {
                Console.WriteLine("{0} completed: {1}", workerName, t.Result);
            });

            task.Start();
        }
        Task.WaitAll(tasks);
    }

Part B: Async and Await

1. Refactor DoWork to return a Task<int>
   - Call Task.FromResult to return the result

2. Refactor UseTasks to return a Task
   - Remove the Task array and call to WaitAll
   - Replace new Task with a call that awaits Task.Run, passing
     a lambda that execeutes DoWork

    private async static Task UseTasks()
    {
        const int units = 5;
        Console.WriteLine("Number of tasks:");

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            var workerName = string.Format("Task {0}", i + 1);

            int result = await Task.Run(() => DoWork(units));

            // Compiled as a continuation callback
            Console.WriteLine("{0} completed: {1}", workerName, result);
        }
    }

3. Update Program.Main to return a task from UseTasks, then call Wait on the task
   in order to block the main thread until the task has completed

    var task = UseTasks();
    task.Wait();

