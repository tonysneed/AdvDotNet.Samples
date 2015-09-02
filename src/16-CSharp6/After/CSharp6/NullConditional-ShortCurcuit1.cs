// Null Conditional Operators: Short Curcuiting with 'as' Operator
namespace NullConditional_ShortCurcuit1
{
    using System;
    using System.IO;

    // C# 5:
    // Need if statement to check for null
    public class Utility_CS5 : IDisposable
    {
        StreamReader _reader;

        public Utility_CS5(string path)
        {
            _reader = new StreamReader(path);
        }

        public void Dispose()
        {
            var disp = _reader as IDisposable;
            if (disp != null)
                disp.Dispose();
        }
    }

    // C# 6:
    // Null conditional operator simplifies null-checking
    public class Utility_CS6 : IDisposable
    {
        StreamReader _reader;

        public Utility_CS6(string path)
        {
            _reader = new StreamReader(path);
        }

        public void Dispose()
        {
            var disp = _reader as IDisposable;
            disp?.Dispose();
        }
    }
}
