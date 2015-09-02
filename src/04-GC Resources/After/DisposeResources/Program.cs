using System;
using System.IO;

namespace DisposeResources
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"c:\temp\sample.txt"))
            {
                Console.WriteLine(reader.ReadToEnd());
            } // Dispose called in a finally block

            //var reader = new StreamReader(@"c:\temp\sample.txt");
            //try
            //{
            //    Console.WriteLine(reader.ReadToEnd()); // maybe an exception occurs
            //}
            //finally
            //{
            //    reader.Dispose();
            //}

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
