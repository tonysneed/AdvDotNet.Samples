namespace IOAsync.Entities
{
    public class Category : EntityBase
    {
        private int _categoryId;
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                if (value == _categoryId) return;
                _categoryId = value;
                NotifyPropertyChanged();
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (value == _categoryName) return;
                _categoryName = value;
                NotifyPropertyChanged();
            }
        }
    }
}
