// nameof Expressions
namespace NameOfExpression
{
    using System.ComponentModel;

    // C# 5:
    // Specifying string literals for members is error-prone
    public class Customer_CS5 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                _name = value;
            }
        }
    }

    // C# 6:
    // With nameof compiler inserts string literal
    //public class Customer_CS6 : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private string _name;
    //    public string Name
    //    {
    //        get { return _name; }
    //        set
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
    //            _name = value;
    //        }
    //    }
    //}
}
