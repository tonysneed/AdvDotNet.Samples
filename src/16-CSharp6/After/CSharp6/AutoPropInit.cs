// Auto Property Initializers
namespace AutoPropInit
{
    // C# 5:
    // Need to add backing field for property initialization
    public class Customer_CS5
    {
        private string _name = "Joe"; // Field initializer
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    // C# 6:
    // Now you can initialize auto properties
    public class Customer_CS6
    {
        public string Name { get; set; } = "Joe"; // Prop initializer
    }
}
