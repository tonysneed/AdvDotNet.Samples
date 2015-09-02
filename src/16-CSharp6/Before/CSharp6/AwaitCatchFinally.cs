// Await in Catch and Finally
namespace AwaitCatchFinally
{
    using System;
    using System.Threading.Tasks;

    // C# 5:
    // Cannot await method calls in catch or finally
    public class Utility_CS5
    {
        public void DoSomething()
        {
            try
            {
                int i = 0;
                double d = 5 / i;
            }
            catch (DivideByZeroException ex)
            {
                // Blocks executing thread
                LogAsync(ex).Wait();
            }
        }

        private async Task LogAsync(Exception ex)
        {
            await Task.Delay(500);
            Console.WriteLine(ex.Message);
        }
    }

    // C# 6:
    // Can await method calls in catch or finally
    //public class Utility_CS6
    //{
    //    public async void DoSomething()
    //    {
    //        try
    //        {
    //            int i = 0;
    //            double d = 5 / i;
    //        }
    //        catch (DivideByZeroException ex)
    //        {
    //            // Does NOT block executing thread
    //            await LogAsync(ex);
    //        }
    //    }

    //    private async Task LogAsync(Exception ex)
    //    {
    //        await Task.Delay(500);
    //        Console.WriteLine(ex.Message);
    //    }
    //}
}
