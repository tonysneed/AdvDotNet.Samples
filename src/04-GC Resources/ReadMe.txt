GC and Resource Management ReadMe

Note: Before projects are blank.

Part A: Garbage Collection: Roots

1. Add r1 static root object

2. Add r2 local root object

3. Add r3 local root object
   - call r3.ToString at the end of Main
   
4. Add weak references for each root

5. Add code to perform a GC
   - Then check to see if weak ref is alive
   
    private static object r1 = new object();
    static void Main1(string[] args)
    {
        r1 = null;
        var w1 = new WeakReference(r1);
        GC.Collect(2);
        Console.WriteLine("r1 is alive: {0}", w1.IsAlive);

        object r2 = new object();
        var w2 = new WeakReference(r2);
        GC.Collect(2);
        Console.WriteLine("r2 is alive: {0}", w2.IsAlive);

        object r3 = new object();
        var w3 = new WeakReference(r3);
        GC.Collect(2);
        Console.WriteLine("r3 is alive: {0}", w3.IsAlive);

        r3.ToString();
    }

6. Set the build to Release and inspect output

7. Set the build to debug and inspect output

Part B: Garbage Collection: Generations

1. Add int count = 10000000 (ten million)

2. Create an object array of count

3. Add a for look over the array
   - create an object without a root
   
    new object();
    
4. Add code to time the iteration using a stopwatch

5. Print out milliseconds and GC counts for gens 0, 1 and 2
   - Note that all GC's take place in Gen0
   
6. Update the code to overwrite a random array element with a new object
   - Replace the new object creation with this line of code

    objects[rng.Next(count)] = new object();

7. Run the program again to observe the performance difference,
   as well as the number of gen 0, 1 and 2 collections which take place

Part C: Deterministic finalization with IDisposable

1. Write code which reads the contents of a text file

    var reader = new StreamReader(@"c:\temp\sample.txt");
    Console.WriteLine(reader.ReadToEnd()); // maybe an exception occurs

2. Add code which keeps the program running

    Console.WriteLine("Press Enter to exit");
    Console.ReadLine();

3. Run the app and observe that the file cannot be changed or deleted

4. To release the file lock, use a try / catch in which reader.Dispose
   is called in the try
   - Throw an exception before calling Dispose
   - Notice that Dispose does not get called
   
5. Move the call to Dispose to a finally block
   - This time Dispose should get called even if there is an exception
   
6. Replace the try / finally with a using statement
   - Dispose will be called in a finally block at the end of the statement
   


