using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PL.PO;
    public class OrderForList: DependencyObject
{
    public int ID
    {
        get { return (int)GetValue(IDProperty); }
        set { SetValue(IDProperty, value); }
    }
    public string? CustomerName
    {
        get { return (string)GetValue(CustomerNameProperty); }
        set { SetValue(CustomerNameProperty, value); }
    }

    public BO.OrderStatus? Status
    {
        get { return (BO.OrderStatus)GetValue(StatusProperty); }
        set { SetValue(StatusProperty, value); }
    }
    public int AmountOfItems
    {
        get { return (int)GetValue(AmountOfItemsProperty); }
        set { SetValue(AmountOfItemsProperty, value); }
    }

    public double TotalPrice
    {
        get { return (double)GetValue(TotalPriceProperty); }
        set { SetValue(TotalPriceProperty, value); }
    }

    public OrderForList( object obj)
    {
        BO.OrderForList o= (BO.OrderForList)obj;
        this.ID = o.ID;
        this.TotalPrice = o.TotalPrice;
        this.CustomerName = o.CustomerName;
        this.AmountOfItems = o.AmountOfItems;//???????????????
        this.Status = o.Status;
    }
    public OrderForList()
    {}

    public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(int), typeof(OrderForList), new UIPropertyMetadata(0));

    public static readonly DependencyProperty CustomerNameProperty = DependencyProperty.Register("CustomerName", typeof(string), typeof(OrderForList), new UIPropertyMetadata(""));


    public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("StatusProperty", typeof(BO.OrderStatus), typeof(OrderForList));

    public static readonly DependencyProperty AmountOfItemsProperty = DependencyProperty.Register("AmountOfItems", typeof(int), typeof(OrderForList));

    public static readonly DependencyProperty TotalPriceProperty = DependencyProperty.Register("TotalPrice", typeof(double), typeof(OrderForList), new UIPropertyMetadata(0.0));
}

