// String Interpolation
namespace StringInterpolation
{
    // C# 5:
    // {0} placeholders with string.Format are error-prone
    public class Utility_CS5
    {
        public string AsCurrency(decimal amount)
        {
            return string.Format("Amount: {0:C}", amount);
        }
    }

    // C# 6:
    // $ string prefix allows placeholders with variables or expressions
    public class Utility_CS6
    {
        public string AsCurrency(decimal amount)
        {
            return $"Amount: {amount:C}";
            //return $"Amount: {(amount == 0 ? "" : amount.ToString("C"))}";
        }
    }
}
