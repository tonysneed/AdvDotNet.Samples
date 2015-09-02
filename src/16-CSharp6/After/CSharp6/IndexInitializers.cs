// Index Initializers
namespace IndexInitializers
{
    using System.Collections.Generic;

    // C# 5:
    // Syntax awkward for initializing a dictionary
    public class Utility_CS5
    {
        public Utility_CS5()
        {
            Numbers = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
            };
        }
        public Dictionary<int, string> Numbers { get; private set; }
    }

    // C# 6:
    // With nameof compiler inserts string literal
    public class Utility_CS6
    {
        public Utility_CS6()
        {
            Numbers = new Dictionary<int, string>
            {
                [1] = "one",
                [2] = "two",
                [3] = "three",
            };
        }
        public Dictionary<int, string> Numbers { get; private set; }
    }
}
