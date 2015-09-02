// Null Conditional Operators: Short Curcuiting with Event
namespace NullConditional_ShortCurcuit2
{
    using System;

    // C# 5:
    // Need if statement to check for null
    public class Worker_CS5
    {
        public event Action WorkStarted;

        public void Work()
        {
            if (WorkStarted != null)
                WorkStarted();
        }
    }

    // C# 6:
    // Null conditional operator simplifies null-checking
    //public class Worker_CS6
    //{
    //    public event Action WorkStarted;

    //    public void Work()
    //    {
    //        WorkStarted?.Invoke();
    //    }
    //}
}
