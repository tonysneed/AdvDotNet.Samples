using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to crash.");
            Console.ReadLine();

            try
            {
                Divide(1, 0);
            }
            catch (DivideByZeroException e)
            {
                throw new MyCustomException("Another crash and burn.", e);
            }
        }

        static double Divide(int a, int b)
        {
            return a / b;
        }
    }
}
