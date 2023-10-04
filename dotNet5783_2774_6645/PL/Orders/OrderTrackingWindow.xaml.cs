using BlApi;
using DalApi;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace PL.Orders
{
    /// <summary>
    /// Interaction logic for OrderTrackingWindow.xaml
    /// </summary>
    public partial class OrderTrackingWindow : Window
    {
        IBl bl;
        public OrderTrackingWindow(IBl Bl)
        {
            bl = Bl;
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int orderId = int.Parse(orderIdBtn.Text);
                BO.OrderTracking oTracking = bl.order.OrderTracking(orderId);
                orderTrackingTxt.Text = oTracking.ToString();
            }
            catch(BlIdNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int orderId = int.Parse(orderIdBtn.Text);
                bl.order.GetOrder(orderId);
                new OrderWindow(bl, orderId, false).Show();
            }
            catch(BlIdNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
