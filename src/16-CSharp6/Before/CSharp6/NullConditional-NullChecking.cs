// Null Conditional Operators: Null Checking
namespace NullConditional_NullChecking
{
    using System;

    // C# 5:
    // Use if statement or ternary operator to check for null
    public class Utility_CS5
    {
        // If name is not null, return all caps; otherwise return null
        public string AllCapsOrNull(string name)
        {
            // Use if statement to check for null
            string caps = null;
            if (name != null)
                caps = name.ToUpper();
            return caps;
        }

        // If name is not null, return all caps; otherwise return empty string
        public string AllCapsOrEmpty(string name)
        {
            // Use ternary operator to check for null
            string caps = name != null ? name.ToUpper() : string.Empty;
            return caps;
        }
    }

    // C# 6:
    // Use null conditional operator to check for null
    //public class Utility_CS6
    //{
    //    // If name is not null, return all caps; otherwise return null
    //    public string AllCapsOrNull(string name)
    //    {
    //        string caps = name?.ToUpper();
    //        return caps;
    //    }

    //    // If name is not null, return all caps; otherwise return empty string
    //    public string AllCapsOrEmpty(string name)
    //    {
    //        string caps = name?.ToUpper() ?? string.Empty;
    //        return caps;
    //    }
    //}
}
