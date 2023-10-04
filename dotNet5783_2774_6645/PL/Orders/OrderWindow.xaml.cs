using BlApi;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using PL.Carts;
using PL.General;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PL.Orders
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        IBl bl;
        int orderId;
        public PO.Order pOrder { get; set; }
        public bool isAdmin { get; set; }
        ObservableCollection<PO.OrderForList> orders;
        public BO.OrderStatus? Status
        {
            get { return (BO.OrderStatus?)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(BO.OrderStatus?), typeof(OrderWindow));


        public OrderWindow(IBl Bl, int id, bool admin = true, ObservableCollection<PO.OrderForList>? o = null)
        {
            InitializeComponent();
            bl = Bl;
            isAdmin = admin;
            orders = o;
            orderId = id;
            try
            {
                pOrder = new(bl.order.GetOrder(id));
            }
            catch (BlIdNotFound e)
            {
                MessageBox.Show(e.Message + e.InnerException);
            }
            Status = pOrder!.Status;
            DataContext = this;
        }

        private void updateDliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.order.UpdateDeliveryOrder(orderId);

                pOrder.DeliveryDate = bl.order.GetOrder(orderId).DeliveryDate;
                int idx = orders.ToList().FindIndex(o => orderId == o.ID);

                PO.OrderForList? order = orders.ToList().Find(o => orderId == o.ID);
                orders.Remove(order);
                order.Status = BO.OrderStatus.DeliveredToCustomer;
                orders.Insert(idx, order);
                Status = pOrder.Status = BO.OrderStatus.DeliveredToCustomer;
            }
            catch (BlInvalidStatusException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (PlNullObjectException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BlIdNotFound ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void updateShipedBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.order.UpdateShipedOrder(orderId);
                int idx = orders.ToList().FindIndex(o => orderId == o.ID);
                PO.OrderForList order = orders.ToList().Find(o => orderId == o.ID) ?? throw new PlNullObjectException();
                orders.Remove(order);
                order.Status = BO.OrderStatus.Sent;
                orders.Insert(idx, order);
                Status = pOrder.Status = BO.OrderStatus.Sent;
                pOrder.ShipDate = bl.order.GetOrder(orderId).ShipDate;
            }
            catch (BlInvalidStatusException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (PlNullObjectException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BlIdNotFound ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }

        }

        private void changeProductAmountBtn_Click(object sender, RoutedEventArgs e)
        {
            List<BO.OrderItem> lst = new List<BO.OrderItem>(pOrder.Items!.ToList()!);
            BO.OrderItem product = (BO.OrderItem)((Button)sender).DataContext;
            int newAmount = (((Button)sender).Name == "addProductAmountBtn") ? product.Amount + 1 : product.Amount - 1;
            pOrder.TotalPrice = (pOrder.TotalPrice - product.Price * product.Amount) + product.Price * newAmount;
            product.Amount = newAmount;
            if (newAmount.Equals(0))
                lst.Remove(product);
            else
                lst[lst.FindIndex(i => i.ProductID == product.ProductID)] = product;
            pOrder.Items = lst;

        }


        //private void deleteBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    List<BO.OrderItem> lst = new List<BO.OrderItem>(poOrder.Items.ToList());
        //    BO.OrderItem product = (BO.OrderItem)((Button)sender).DataContext;
        //    poOrder.TotalPrice -= product.Price * product.Amount;
        //    product.Amount = 0;
        //    lst[lst.FindIndex(i => i.ProductID == product.ProductID)] = product;
        //    poOrder.Items = lst;
        //}

        private void updateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Order o = new();
                // BO.Order o = PLUtils.cast<BO.Order, PO.Order>(pOrder);
                o.Status = pOrder.Status;
                o.OrderDate = pOrder.OrderDate;
                o.ShipDate = pOrder.ShipDate;
                o.CustomerName = pOrder.CustomerName;
                o.CustomerAddress = pOrder.CustomerAddress;
                o.CustomerEmail = pOrder.CustomerEmail;
                o.DeliveryDate = pOrder.DeliveryDate;
                o.Items = pOrder.Items;
                o.ID = pOrder.ID;
                int idx = orders.ToList().FindIndex(o => pOrder.ID == o.ID);
                orders.RemoveAt(idx);
                PO.OrderForList orderForList = PLUtils.cast<PO.OrderForList, BO.OrderForList>(PLUtils.cast<BO.OrderForList, PO.Order>(pOrder));
                orderForList.AmountOfItems = bl.order.UpdateOrder(o) ?? throw new PlNullObjectException();
                orders.Insert(idx, orderForList);
                Close();
            }
            catch (BlInvalidAmount ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BlNegativeAmountException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BlIdNotFound ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
            catch (PlNullObjectException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listOfProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


