Thread Synchronization ReadMe

Part A: Kernel Locks - Wait Handle

The existing code spawns some worker thread which each do 5 units of work each. They
are set as background threads, so they do not keep the app running while executing.
Our task is to use event wait handles to block the main thread until all are done.

1. Run the app and notice how it exits after just one iteration.

2. Add a static field to Program which is an array of WaitHandle

    static readonly WaitHandle[] Waits = new WaitHandle[ThreadCount];

3. Inside the for loop in Main set each array element to a new AutoResetEvent
   - Initialize them to a non-signaled state (false)
   
    Waits[i] = new AutoResetEvent(false);

4. Pass index to Start method on thread

    worker.Start(i);

5. Place code after for loop in Main which waits on for all threads to complete

    WaitHandle.WaitAll(Waits);

6. Add code to DoWork which signals event when work has completed

    AutoResetEvent wait = (AutoResetEvent)Waits[(int) arg];
    wait.Set();

7. Run the app to observe that the main thread blocks until all have signaled
   their event wait handle

Part B: Kernel Locks - Mutex

In this example we'll use a named mutex to synchonize across processes.

1. Start two instances of the app by pressing Ctrl+F5 twice.
   - Notice that there is no synchronization between the alternation of colors
     between the two instances

2. Because we are using a named mutex, we need to ensure a 1-1 correlation between
   native and managed threads.
   - Place a call to Thread.BeginThreadAffinity at the top of Program.Main
   - Place a call to Thread.EndThreadAffinity at the bottom of Program.Main

3. Next create a new Mutex and give it a name
   - Set the first parameter to false so that it is not initially owned

    var mutex = new Mutex(false, "StopNGo");

4. In the try block call mutex.WaitOne

5. In the finally block call mutex.ReleaseMutex

6. Run the two instances again
   - Observe this time that instances are suynchronized when switching colors

Part C: Hybrid Locks - SemaphoreSlim

Here we'll use a SemaphoreSlim to block a thread until work on another thread
has completed. This is similar to how we would use an AutoResetEvent, but it
does not make use of a kernel sync object.

1. Run the program to observe that the main thread is not blocked,
   and the app exits without waiting for the async work to complete.

2. Create a semaphore with init count of 0 and max count of 1

    var semaphore = new SemaphoreSlim(0, 1);

3. When starting the thread, pass the semaphore as an argument.

    worker.Start(semaphore);

4. Then in Main wait on the semaphore

    semaphore.Wait();

5. At the end of DoWork cast the arg to a SemaphoreSlim and call Release

    var semaphore = (SemaphoreSlim)arg;
	semaphore.Release();

6. Run the program again to verify that the main thread blocks until it
   is signaled

Part D: Hybrid Locks - Monitor

We need to add synchronization code to a Business class, so that two
operations become atomic.

1. Run the app and notice that Receivables is incrementing correctly
   but Cash is not (it's incremented to 1000 before it's printed).

2. Add a _sharedLock field of type object to the Business class

3. Place the lock statement around code in Payment for adjusting Cash and Receivables
   - Pass the shared lock object
   - This can cause a deadlock if a thread does not release the lock

4. After incrementing Cash add code that causes a deadlock

    if (Cash == 500) Thread.Sleep(Timeout.Infinite);

5. Remove the lock statment, then add a call to Monitor.TryEnter,
   specifying a timeout of 1000 milliseconds
   - If TryEnter returns false, exit with message to Console
   - Follow with try / finally
   - In try perform the operations
   - In finally call Monitor.Exit

6. Run the program again to observe that the final balances are as follows:
   Cash = 300
   Receiveables = 700
   - It's also possible for cash to be 200 and Receiveables 800

Part E: Async Locks - SemaphoreSlim

This example uses a simple calculate that returns the value of pi up to a
specified number of decimal places (max is 15). The longer the places, the
longer the calculation takes to complete. We can use a SemaphoreSlim with
an async lock to sync with the main thread without blocking it.

1. Run the app to observe the UI become non-responsive because the main
   thread is blocked while the calculator is working.

2. Add a field to the main form code behind of type SemaphoreSlim
   - Initialize with init count of 0 and max count of 1

3. Remove the call to worker.Join() and replace it with _semaphore.Wait().
   - At the end of the CalculatePi method, call _semaphore.Release()
   - Note the main thread remains blocked by the call to _semaphore.Wait

4. Replace _semaphore.Wait with _semaphore.WaitAsync
   - await the call to WaitAsync
   - Mark the calcButton_Click as async

5. Run the app again to observe that the UI thread no longer blocks