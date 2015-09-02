// Expression Bodied Members
namespace ExpressionBodied
{
    using System;
    using System.Collections.Generic;

    // C# 5:
    // Methods and properties require a body
    public class Calculator_CS5
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Pi
        {
            get { return Math.PI; }
        }
    }

    // C# 6:
    // Lambda expressions can replace method or property bodies
    //public class Calculator_CS6
    //{
    //    public int Add(int a, int b) => a + b; // Expression as method body
    //    public double Pi => Math.PI; // Expression as property body
    //    public Calculator_CS6 this[int id] => _calculators[id];
    //    List<Calculator_CS6> _calculators = new List<Calculator_CS6>();
    //}
}
