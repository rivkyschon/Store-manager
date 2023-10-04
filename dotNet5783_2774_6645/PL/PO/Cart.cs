﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PL.PO;
/// <summary>
/// A PO entity of shopping BOcart
/// for the shopping BOcart management screen and order confirmation
/// </summary>
public class Cart : DependencyObject
{
    public int UserID
    {
        get { return (int)GetValue(UserIdProperty); }
        set { SetValue(UserIdProperty, value); }
    }
    public string? CustomerName
    {
        get { return (string)GetValue(customerNameProperty); }
        set { SetValue(customerNameProperty, value); }
    }
    public string? CustomerEmail
    {
        get { return (string)GetValue(customerEmailProperty); }
        set { SetValue(customerEmailProperty, value); }
    }
    public string? CustomerAddress
    {
        get { return (string)GetValue(customerAddressProperty); }
        set { SetValue(customerAddressProperty, value); }
    }
    public ObservableCollection<PO.OrderItem> Items
    {
        get { return (ObservableCollection<PO.OrderItem>)GetValue(itemsProperty); }
        set { SetValue(itemsProperty, value); }
    }
    public double TotalPrice
    {
        get { return (double)GetValue(totalPriceProperty); }
        set { SetValue(totalPriceProperty, value); }
    }

    public static readonly DependencyProperty customerNameProperty = DependencyProperty.Register("CustomerName", typeof(string), typeof(Cart), new UIPropertyMetadata(""));
    public static readonly DependencyProperty customerEmailProperty = DependencyProperty.Register("CustomerEmail", typeof(string), typeof(Cart), new UIPropertyMetadata(""));
    public static readonly DependencyProperty customerAddressProperty = DependencyProperty.Register("CustomerAddress", typeof(string), typeof(Cart), new UIPropertyMetadata(""));
    public static readonly DependencyProperty totalPriceProperty = DependencyProperty.Register("TotalPrice", typeof(double), typeof(Cart), new UIPropertyMetadata(0.0));
    public static readonly DependencyProperty UserIdProperty = DependencyProperty.Register("UserId", typeof(int), typeof(Cart), new UIPropertyMetadata(0));
    public static readonly DependencyProperty itemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<PO.OrderItem?>), typeof(Cart), new UIPropertyMetadata(new ObservableCollection<PO.OrderItem?>()));
}
