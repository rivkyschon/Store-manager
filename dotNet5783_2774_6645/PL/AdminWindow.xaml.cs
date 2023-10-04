using BlApi;
using PL.Products;
using PL.Orders;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        IBl bl;
        
        public AdminWindow(IBl Bl)
        {
            bl = Bl;
            InitializeComponent();
        }

        private void ProductListWindow_Click(object sender, RoutedEventArgs e)
        {
            new ProductListWindow(bl).Show();
        }

        private void OrderListWindow_Click(object sender, RoutedEventArgs e)
        {
            new OrderListWindow(bl).Show();
        }
    }
}
