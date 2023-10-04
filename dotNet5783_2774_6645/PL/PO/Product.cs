using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BO;

namespace PL.PO
{
    public class Product : DependencyObject
    {

        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public double Price
        {
            get { return (double)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public int InStock
        {
            get { return (int)GetValue(InStockProperty); }
            set { SetValue(InStockProperty, value); }
        }
        public BO.eCategory? Category
        {
            get { return (BO.eCategory)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public string? Image
        {
            get { return (string?)GetValue(imgProperty); }
            set { SetValue(imgProperty, value); }
        }


        public Product() { }


        public Product(BO.Product p)
        {
            Name = p.Name;
            Price = p.Price;
            Category = p.Category;
            InStock = p.InStock;
            ID = p.ID;
            Image = p.Image;
        }

        public static readonly DependencyProperty imgProperty = DependencyProperty.Register("Image", typeof(string), typeof(Product));
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(int), typeof(Product));
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Product));
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(double), typeof(Product));
        public static readonly DependencyProperty InStockProperty = DependencyProperty.Register("InStock", typeof(int), typeof(Product), new UIPropertyMetadata(0));
        public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register("Category", typeof(BO.eCategory), typeof(Product), new UIPropertyMetadata(null));
    }
}




