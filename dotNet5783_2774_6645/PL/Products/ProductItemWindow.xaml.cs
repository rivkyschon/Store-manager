using BlApi;
using BlImplementation;
using BO;
using PL.Carts;
using PL.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL.Products
{
    /// <summary>
    /// Interaction logic for ProductItemWindow.xaml
    /// </summary>
    public partial class ProductItemWindow : Window
    {
        IBl bl;
        PO.Cart cart_;
        bool isRegistered;
        public List<string> lst { get; set; }
        public ObservableCollection<PO.ProductItem> products { get; set; } = new();


        public ProductItemWindow(IBl Bl, PO.Cart Cart, int userID = 0, bool isReg = false)
        {
            InitializeComponent();
            bl = Bl;
            cart_ = Cart;
            isRegistered = isReg;
            cart_.UserID = userID;
            lst = Enum.GetNames(typeof(BO.eCategory)).ToList();
            lst.Insert(0, "all categories");
            cast(bl.product.GetProductItem());
            DataContext = this;
        }
        public void cast(IEnumerable<ProductItem?> enumerable)
        {
            products.Clear();
            enumerable.ToList().ForEach(p => products.Add(PLUtils.cast<PO.ProductItem, BO.ProductItem>(p)));
        }

        private void AttributeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AttributeSelector.SelectedItem.Equals("all categories"))
                cast(bl.product.GetProductItem());
            else
                cast(bl.product.GetProductItem((BO.eCategory)Enum.Parse(typeof(BO.eCategory), AttributeSelector.SelectedItem.ToString())));
        }


        private void ProductsListview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new ProductWindow(bl, "show", null, cart_, ((PO.ProductItem)((ListView)sender).SelectedItem)?.ID ?? throw new PlNullObjectException(), isRegistered).Show();

        }

        private void viewCartBtn_Click(object sender, RoutedEventArgs e)
        {
            new CartWindow(bl, cart_, false, isRegistered).Show();
            Close();
        }
    }
}
