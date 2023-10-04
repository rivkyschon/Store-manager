using BlApi;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using PL.Carts;
using System.Collections;
using BO;
using System.Collections.ObjectModel;
using PL.General;

namespace PL.Products;


/// <summary>
/// Interaction logic for ProductListWindow.xaml
/// </summary>
public partial class ProductListWindow : Window
{
    IBl bl;
    public List<string> lst { get; set; }
    public ObservableCollection<PO.Product> products { get; set; } = new();

    public ProductListWindow(IBl Bl)
    {
        InitializeComponent();

        bl = Bl;
        lst = Enum.GetNames(typeof(BO.eCategory)).ToList();
        lst.Insert(0, "all categories");
        cast(bl.product.GetProductList());
        DataContext = this;
    }

    public void cast(IEnumerable<ProductForList?> enumerable)
    {
        products.Clear();
        enumerable.ToList().ForEach(p => products.Add(PLUtils.cast<PO.Product, BO.ProductForList>(p)));
    }

    private void AttributeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (AttributeSelector.SelectedItem.Equals("all categories"))
            cast(bl.product.GetProductList());
        else
            cast(bl.product.GetProductList((BO.eCategory)Enum.Parse(typeof(BO.eCategory), AttributeSelector.SelectedItem.ToString())));
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        new ProductWindow(bl, "add", products).Show();
    }

    private void ProductsListview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
    new ProductWindow(bl, "update", products, null,((PO.Product?)ProductsListview.SelectedItems[0])?.ID ?? throw new PlNullObjectException()).Show();
    }

}
