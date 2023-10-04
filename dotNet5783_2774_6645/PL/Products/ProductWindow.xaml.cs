using BlApi;
using BlImplementation;
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
using System.Collections.ObjectModel;
using PL.General;

namespace PL.Products;

/// <summary>
/// Interaction logic for ProductWindow.xaml
/// </summary>
public partial class ProductWindow : Window
{
    IBl bl;
    int productID;
    PO.Cart cart;
    public PO.Product currentProduct { get; set; }
    public Array categories { get; set; }
    public string show { get; set; }
    public bool isRegistered { get; set; }
    private ObservableCollection<PO.Product> products { get; set; } = new();
    string imgName;

    public ProductWindow(IBl Bl, string active, ObservableCollection<PO.Product>? Products, PO.Cart? Cart = null, int id = 0, bool isReg = false)
    {
        InitializeComponent();

        bl = Bl;
        cart = Cart;
        isRegistered = isReg;
        products = Products;
        productID = id;
        categories = Enum.GetValues(typeof(BO.eCategory));
        currentProduct = id == 0 ? new() : new(bl.product.GetProductForManager(productID));
        show = active;
        DataContext = this;
    }



    private void Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            products.Remove(products.ToList().Find(po => productID == po.ID));
            currentProduct.ID = bl.product.AddProduct(PLUtils.cast<BO.Product, PO.Product>(currentProduct));
            products.Add(currentProduct);
            Close();
        }
        catch (BlIdNotFound ex) { MessageBox.Show(ex.Message + ex.InnerException); }
        catch (BlNullValueException ex) { MessageBox.Show(ex.Message); }
        catch (BlInvalidAmount ex) { MessageBox.Show(ex.Message); }
        catch (BlInvalideData ex) { MessageBox.Show(ex.Message); }
    }

    private void BtnUpdate_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            bl.product.UpdateProduct(PLUtils.cast<BO.Product, PO.Product>(currentProduct));
            int idx = products.ToList().FindIndex(po => productID == po.ID);
            products.RemoveAt(idx);
            products.Insert(idx, currentProduct);
            Close();
        }
        catch (BlIdNotFound ex) { MessageBox.Show(ex.Message + ex.InnerException); }
        catch (BlNullValueException ex) { MessageBox.Show(ex.Message); }
        catch (BlInvalidAmount ex) { MessageBox.Show(ex.Message); }
        catch (BlInvalideData ex) { MessageBox.Show(ex.Message); }
        catch (BlNegativeAmountException ex) { MessageBox.Show(ex.Message); }
    }

    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            bl?.product.DeleteProduct(productID);
            products.Remove(products.ToList().Find(po => productID == po.ID));
            Close();
        }
        catch (BlProductFoundInOrders ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (BlIdNotFound ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void BtnReturn_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void addToCartBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            PLUtils.castCart(bl.Cart.AddToCart(PLUtils.cast<BO.Cart, PO.Cart>(cart), productID, true), cart);
            Close();
        }
        catch (BlItemAlreadyInCart ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (BlOutOfStockException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (BlIdNotFound ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void changeImageButton_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
        f.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
        if (f.ShowDialog() == true)
        {
            productImg.Source = new BitmapImage(new Uri(f.FileName));
            currentProduct.Image = imgName = f.FileName;
        }

    }
}



