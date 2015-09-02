// Getter-Only Auto Properties
namespace AutoPropGet
{
    // C# 5:
    // Automatic properties require a setter
    public class Customer_CS5
    {
        public Customer_CS5()
        {
            Name = "Joe";
        }

        public string Name { get; private set; }  // Private setter
    }

    // C# 6:
    // Now you can initialize auto properties
    public class Customer_CS6
    {
        public string Name { get; } = "Joe"; // Read-only auto property
    }
}
