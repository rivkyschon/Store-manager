using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PL.PO;

public class User: DependencyObject
{
    public int ID
    {
        get { return (int)GetValue(IDProperty); }
        set { SetValue(IDProperty, value); }
    }
    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }
    public string Email
    {
        get { return (string)GetValue(EmailProperty); }
        set { SetValue(EmailProperty, value); }
    }
    public string Address
    {
        get { return (string)GetValue(AddressProperty); }
        set { SetValue(AddressProperty, value); }
    }

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }
    public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(int), typeof(User));

    public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(User), new UIPropertyMetadata(""));

    public static readonly DependencyProperty EmailProperty = DependencyProperty.Register("Email", typeof(string), typeof(User), new UIPropertyMetadata(""));

    public static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address", typeof(string), typeof(User), new UIPropertyMetadata(""));

    public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(User), new UIPropertyMetadata(""));

}
