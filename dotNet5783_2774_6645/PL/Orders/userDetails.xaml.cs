using BlApi;
using PL.General;
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

namespace PL;

/// <summary>
/// Interaction logic for userDetails.xaml
/// </summary>
public partial class userDetails : Window
{
    PO.Cart cart;
    IBl bl;
    public userDetails(IBl Bl,PO.Cart Cart)
    {
        bl = Bl;
        InitializeComponent();
        cart = Cart;
    }

    private void saveBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            cart.CustomerName = NameTxt.Text;
            cart.CustomerEmail = EmailTxt.Text;
            cart.CustomerAddress = AddressTxt.Text;
            bl.Cart.confirmOrder(PLUtils.cast<BO.Cart, PO.Cart>(cart));
            Close();
        }
        catch (BlInvalidEmailException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (BlNullValueException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
