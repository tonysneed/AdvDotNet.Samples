// Using Static to import extension methods
namespace UsingStaticExtension
{
    using System;

    // using namespace: import extension methods only
    //using System.Linq; // C# 5

    // using static: import both static and extension methods
    using static System.Linq.Enumerable; // C# 6

    // C# 5:
    // Class name needed to invoke static or enum members
    public class Calculator_CS5
    {
        public int[] NumRange(int start, int end)
        {
            //var range = Enumerable.Range(start, end + 1 - start);
            var range = System.Linq.Enumerable.Range(start, end + 1 - start);
            return range.ToArray();
        }
    }

    // C# 6:
    // Use using static to import static or enum members
    //public class Calculator_CS6
    //{
    //    public int[] NumRange(int start, int end)
    //    {
    //        //var range = Enumerable.Range(start, end + 1 - start);
    //        var range = Range(start, end + 1 - start);
    //        return range.ToArray(); // Ext method imported via using static
    //    }
    //}
}
