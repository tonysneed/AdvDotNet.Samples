﻿namespace IOAsync.Entities
{
    public class Product : EntityBase
    {
        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value == _productId) return;
                _productId = value;
                NotifyPropertyChanged();
            }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value == _productName) return;
                _productName = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (value == _unitPrice) return;
                _unitPrice = value;
                NotifyPropertyChanged();
            }
        }

        private bool _discontinued;
        public bool Discontinued
        {
            get { return _discontinued; }
            set
            {
                if (value == _discontinued) return;
                _discontinued = value;
                NotifyPropertyChanged();
            }
        }

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

        private Category _category;
        public Category Category
        {
            get { return _category; }
            set
            {
                if (value == _category) return;
                _category = value;
                NotifyPropertyChanged();
            }
        }
    }
}
