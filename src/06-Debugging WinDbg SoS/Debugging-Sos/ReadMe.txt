Debugging with WinDbg and SOS

This pertains to using WinDbg with SOS and SosEx for post-mortem debugging
with crash and hang dumps captured with AdPlus.

SOS/SOSEX Cheet Sheet: http://theartofdev.wordpress.com/windbg-cheat-sheet

NOTE: To analyze dump files for 32-bit apps (even on an x64 OS) you need to
install the 32-bit version of Debugging Tools for Windows
For 32-bit apps, you will need to use the 32-bit version of AdPlus to generate dump files.

Part A: Exceptions

1. Launch Buggy.exe from Release folder
   - Open cmd prompt as admin
   - adplus -crash -o c:\temp -pn Buggy.exe
   - Click button to crash the app
     > Application set up to allow unhandled exception to terminate the app

2. Launch WinDbg x86 version (not x64)
   - Load dump into WinDbg (Ctrl+D)
   - Copy from Temp to Dumps folder
   - Open WinDbg
   - Ctrl+D: Open crash dump file
   - Load SOS
     > .loadby sos clr

3. Show app threads
   - !threads
   - Exception will be shown on the Main Thread
   - We also need the inner exception and the stack trace

4. Now try PrintException
   - !pe
   - Will state there are nested exceptions
   - !pe -nested
   - Nested exceptions will be shown, each with its own stack trace

5. Improve dump quality with INI file
   - PrintException masks fact that exception occurred in property getter for Item
     > This is because JIT-optimized code inlined the Item get method
   - To turn off JIT optimization and get a better dump, we need to an an INI file
     to the bin\Release dir
     > Name it Buggy.ini
     > Content:

[.NET Framework Debugging Control]
GenerateTrackingInfo=1
AllowOptimize=0

   - Generate another dump file and invoke !pe again
     > This time we will see that the error occurred in the Item get method

6. Now try DumpHeap
   - !dumpheap -stat
   - Then filter for Exceptions
     > !dumpheap -stat -type Exception

7. Try CLR stack with parameters
   - Show thread stack with parameters
     > !clrstack –a
   - Dump object details
     > !do <address of object>
     > Try with address of sender (MainForm)
   - Show total size of object
     > !objsize <address of object>
     > Will show size of object and all objects referenced by it

Part B: Threads - Hangs

1. Start with HangMe.exe
   - Start the program
   - Take a hang dump using AdPlus
   - Open dump file with WinDbg
     > load sos and sosex
   - Use !dlk to find the deadlock

2. Then open service and client for Debugging-Blocker
   - Start Blocker.Service
   - Add perf mon counters
     > logical threads
     > total contentions
   - Start Blocker.Client
     > Click Go and let it run for a while
   - Take a hang dump using AdPlus
   - Use !threads to see threads
     > Notice that there is little reuse of existing threads
       This is because a large number are blocking at any given moment
   - Use !syncblk to see locks that are used
   - Use ~#e !clrstack to see a thread stack (notice call to Monitor.Enter)
     > Adding -a to !clrstack will not show the argument for Monitor.Enter
   - To get the referenced object you need to set focus to the thread in question
     > Then execute !dso to dump the objects on the thread stack
     > From there you should see the object reference and match it up to
       the object used for the syncblk by the thread that owns the object

3. Now use SosEx commands to diagnose blocking threads
   - Use !mlocks to see number of sync blocks in use - C# locks
   - Use !mwiats to see threads waiting on locks
     > There should be a large number of threads waiting on the lock

4. Lastly, run the async version of Blocker.Service
   - Check the Async option in the client UI, then click Go
   - After waiting a while, take a hang dump with AdPlus
   - Use same techniques as above to look for blocking threads
     > Notice there are no locks being held or waited on


Part C: Threads - Runaway

1. Start the Runaway app
   - Open Task Manager, then Resource Monitor
   - Notice CPU usage spike

2. Take a hang dump and look at the threads
   - !threads
   - !runaway

Part D: Memory

1. Run the LeakMe app
   - Take a hang dump

2. Use WinDbg
   - !dumpheap -stat

3. Zero in on objects taking up a lot of memory
   - !dumpheap -mt <method table address>

4. Pick one of the objects and locate the object referencing it
   - !gcroot <object address> 

Part D: Memory Leaks - Events

NOTE: In order for SOS and SosEx to diagnose the cause of a memory
leak, there needs to be hard references to objects, so that !gcroots
can chase down object roots. Otherwise, a commercial profiler will be
needed, such as ANTS from Red Gate.

This may be helpful: http://blogs.msdn.com/b/delay/archive/2009/03/11/where-s-your-leak-at-using-windbg-sos-and-gcroot-to-diagnose-a-net-memory-leak.aspx

1. Run Leaky app
   - Click all the buttons
   - Notice the large amount of memory in Task Manager (Commit Size)

2. Generate hang dump with AdPlus x86
   - First add Leaky.ini file to bin Release dir
   - adplus -hang -o c:\temp -pn Leaky.exe

3. Open WinDbg x86
   - .loadby sos
   - .load sosex

4. Dump the heap with stats
   - !dumpheap -stat

5. Locate objects lingering in memory
   - !dumpheap -mt <method table address>

6. Copy an object address and search for roots
   - !gcroot <object address>

7. Working from the buttom up, analyze the root chain
   - Array is referenced by array of arrays, then Generic List
   - Then HogForm, then EventHander
   - !do <address of EventHandler>

8. Get native code of _methodPtr
   - !dumpmd <method pointer address>

9. Get method name
   - !u <address of eax instruction>

Part E: Memory Leaks - Finalizers

1. Run BadFinalizer
   - Open Task Manager to see Commit Size
   - Enter N to see app without leaks
   - Enter Y to see app with a leak

2. Take a hang dump with AdPlus x86
   - First copy ini file to bin Release
   - Then copy pdb file from release to Symbols dir
   - adplus -hang -o c:\temp -pn BadFinalizer

3. Look at objects on the heap, see gc roots
   - !dumpheap -stat
   - !dumpheap -mt <method table address>
   - !gcroot <object address>
     > objects should not have a root

4. Look at Finalization Queue
   - !finalizequeue
   - Notice the large number of GCMe objects in the queue
     > This tells us the objects are not being finalized

