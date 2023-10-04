using BlApi;
using BlImplementation;
using PL.Products;
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
using PL.General;

namespace PL.Orders
{
    /// <summary>
    /// Interaction logic for OrderForList.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        IBl bl;

        ObservableCollection<PO.OrderForList> orders { get; set; } = new();


        public OrderListWindow(IBl Bl)
        {
            bl = Bl;
            InitializeComponent();
            try
            {
                orders = new ObservableCollection<PO.OrderForList>(from item in bl.order.OrderList()
                                                                   select new PO.OrderForList(item));
            }
            catch (BlNullValueException e)
            {
                MessageBox.Show(e.Message);
            }
            OrderListView.ItemsSource = orders;
        }


        private void OrderListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new OrderWindow(bl, ((PO.OrderForList?)OrderListView.SelectedItems[0])?.ID ?? throw new PlNullObjectException(),true, orders).Show();
        }
    }
}
