using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace PL.PO;
/// <summary>
/// A PO entity of an item in the order 
/// (represents a row in the order) 
/// for a list of items in the shopping cart_ screen and in the order details screen
/// </summary>
public class Order : DependencyObject
{
    public int ID
    {
        get { return (int)GetValue(IDProperty); }
        set { SetValue(IDProperty, value); }
    }

    public int? UserID
    {
        get { return (int?)GetValue(UserIDProperty); }
        set { SetValue(UserIDProperty, value); }
    }
    public string? CustomerName
    {
        get { return (string)GetValue(CustomerNameProperty); }
        set { SetValue(CustomerNameProperty, value); }
    }

    public string? CustomerEmail
    {
        get { return (string)GetValue(CustomerEmailProperty); }
        set { SetValue(CustomerEmailProperty, value); }
    }

    public string? CustomerAddress
    {
        get { return (string)GetValue(CustomerAddressProperty); }
        set { SetValue(CustomerAddressProperty, value); }
    }
    public DateTime? OrderDate
    {
        get { return (DateTime?)GetValue(OrderDateProperty); }
        set
        {
            if (value.ToString() != "")
            {
                SetValue(OrderDateProperty, value);
            }
            else { SetValue(OrderDateProperty, null); }
        }
    }

    public DateTime? ShipDate
    {
        get { return (DateTime?)GetValue(ShipDateProperty); }
        set { 
            if (value.ToString() != "")
            {
                SetValue(ShipDateProperty, value);
            }
            else { SetValue(ShipDateProperty, null); }
             }
    }

    public DateTime? DeliveryDate
    {
        get { return (DateTime?)GetValue(DeliveryDateProperty); }
        set
        {
            if (value.ToString() != "")
            {
                SetValue(DeliveryDateProperty, value);
            }
            else { SetValue(DeliveryDateProperty, null); }
        }
    }
    public BO.OrderStatus? Status
    {
        get { return (BO.OrderStatus?)GetValue(StatusProperty); }
        set { SetValue(StatusProperty, value); }
    }
    public IEnumerable<BO.OrderItem?>? Items
    {
        get { return (IEnumerable<BO.OrderItem>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }

    public double TotalPrice
    {
        get { return (double)GetValue(TotalPriceProperty); }
        set { SetValue(TotalPriceProperty, value); }
    }

    public Order(BO.Order o)
    {
        ID = o.ID;
        OrderDate = o.OrderDate;
        ShipDate= o.ShipDate;
        DeliveryDate = o.DeliveryDate;
        TotalPrice = o.TotalPrice;
        CustomerAddress = o.CustomerAddress;
        CustomerEmail = o.CustomerEmail;
        CustomerName = o.CustomerName;
        Items = o.Items;
        Status = o.Status;
    }

    public Order()
    {
    }

    public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(int), typeof(Order), new UIPropertyMetadata(0));

    public static readonly DependencyProperty UserIDProperty = DependencyProperty.Register("UserID", typeof(int?), typeof(Order), new UIPropertyMetadata(0));

    public static readonly DependencyProperty CustomerNameProperty = DependencyProperty.Register("CustomerName", typeof(string), typeof(Order), new UIPropertyMetadata(""));

    public static readonly DependencyProperty CustomerAddressProperty = DependencyProperty.Register("CustomerAddress", typeof(string), typeof(Order), new UIPropertyMetadata(""));

    public static readonly DependencyProperty CustomerEmailProperty = DependencyProperty.Register("CustomerEmail", typeof(string), typeof(Order));

    public static readonly DependencyProperty OrderDateProperty = DependencyProperty.Register("OrderDate", typeof(DateTime?), typeof(Order));

    public static readonly DependencyProperty DeliveryDateProperty = DependencyProperty.Register("DeliveryDate", typeof(DateTime?), typeof(Order));

    public static readonly DependencyProperty ShipDateProperty = DependencyProperty.Register("ShipDate", typeof(DateTime?), typeof(Order), new UIPropertyMetadata(null));

    public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("StatusProperty", typeof(BO.OrderStatus?), typeof(Order));

    public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable<BO.OrderItem>), typeof(Order));

    public static readonly DependencyProperty TotalPriceProperty = DependencyProperty.Register("TotalPrice", typeof(double), typeof(Order), new UIPropertyMetadata(0.0));
}
