// Exception Filters
namespace ExceptionFilters
{
    using System;

    // C# 5:
    // Call stack shows where exception is rethrown
    public class Utility_CS5
    {
        private const int MaxAttempts = 3;

        public void DoSomething()
        {
            int failures = 0;
            for (int i = 0; i < 10; i++)
            {
                try
                {
#pragma warning disable CS0219
                    var local = 100; // No access to local data in stack frame
#pragma warning restore CS0219
                    var data = GetData();
                }
                catch (TimeoutException)
                {
                    if (failures++ < MaxAttempts)
                        Console.WriteLine("Timeout error: trying again");
                    else
                        throw; // Stack shows exception thrown here
                }
            }
        }

        private string GetData()
        {
            throw new TimeoutException();
        }
    }

    // C# 6:
    // Exception filters remove need to re-throw
    public class Utility_CS6
    {
        private const int MaxAttempts = 3;

        public void DoSomething()
        {
            int failures = 0;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    // Stack shows exception thrown here
#pragma warning disable CS0219
                    var local = 100; // Access to local data in stack frame
#pragma warning restore CS0219
                }
                catch (TimeoutException) when (failures++ < MaxAttempts)
                {
                    Console.WriteLine("Timeout error: trying again");
                }
            }
        }

        private string GetData()
        {
            throw new TimeoutException();
        }
    }
}
