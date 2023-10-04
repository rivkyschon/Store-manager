using BlApi;
using System.Windows;
using System.Windows.Controls;
using PL.Products;
using PL.General;

namespace PL.Carts
{

    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        IBl bl;
        bool isRegistered;
        public PO.Cart cart { get; set; }
        public bool isAdmin { get; set; }

        public CartWindow(IBl Bl, PO.Cart Cart, bool admin = false, bool isReg = false)
        {
            bl = Bl;
            isRegistered = isReg;
            InitializeComponent();
            cart = Cart;
            if (isRegistered) initCart();
            isAdmin = admin;
            DataContext = this;
        }

        private void initCart()
        {
        }
        private void confirmOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isRegistered)
                bl.Cart.confirmOrder(PLUtils.cast<BO.Cart, PO.Cart>(cart));
            else
                new userDetails(bl, cart).Show();
            Close();
        }

        private void changeProductAmountBtn_Click(object sender, RoutedEventArgs e)
        {
            PO.OrderItem product = (PO.OrderItem)((Button)sender).DataContext;
            int newAmount = (((Button)sender).Name == "addProductAmountBtn") ? product.Amount + 1 : product.Amount - 1;
            PLUtils.castCart(bl.Cart.updateAmount(PLUtils.cast<BO.Cart, PO.Cart>(cart), product.ProductID, newAmount, isRegistered), cart);
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            PLUtils.castCart(bl.Cart.updateAmount(PLUtils.cast<BO.Cart, PO.Cart>(cart), ((PO.OrderItem)((Button)sender).DataContext).ProductID, 0, isRegistered), cart);
        }

        private void addItemBtn_Click(object sender, RoutedEventArgs e)
        {
            new ProductItemWindow(bl, cart, cart.UserID).Show();
            Close();
        }

    }
}
