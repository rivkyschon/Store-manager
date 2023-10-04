using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PL.Products;
using BlApi;
using PL.Orders;
using PL.User;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBl bl;
        BO.Cart? cart=new();

        public MainWindow()
        {
            InitializeComponent();
            bl = BlApi.Factory.Get;
        }

        private void displayProductListWindow_Click(object sender, RoutedEventArgs e)
        {
            new AdminWindow(bl).Show();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to sign?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
              new SignInWindow(bl).Show();
            }
            else
            {
                new ProductItemWindow(bl, new PO.Cart()).Show();
            }

        }

        private void OrderTrackingBtn_Click(object sender, RoutedEventArgs e)
        {
            new OrderTrackingWindow(bl).Show();
        }


        private void simultorBtn_Click(object sender, RoutedEventArgs e)
        {
            new SimulatorWindow(bl).Show();
        }
    }
}
