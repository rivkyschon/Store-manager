using BlApi;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace PL;

public class PLUtils
{
    public static S cast<S, T>(T t) where S : new()
    {
        object s = new S();
        int a;
        foreach (PropertyInfo prop in t?.GetType().GetProperties() ?? throw new BlNoPropertiesInObject())
        {
            if (prop.Name == "Image")
                a = 5;
            PropertyInfo? type = s.GetType().GetProperty(prop.Name);

            if (type == null) continue;

            var value = t.GetType().GetProperty(prop.Name)?.GetValue(t, null);
            if(type.ReflectedType.FullName== "PL.PO.Product" && prop.ReflectedType.FullName == "BO.ProductItem"&& prop.Name=="InStock")
            {
              value= t.GetType().GetProperty("Amount")?.GetValue(t, null);
            }

            if (type.Name == "Items")
            {
                if (type.ReflectedType.FullName.StartsWith("BO"))
                    type.SetValue(s, castPOItemsToBOItems(value));
                else type.SetValue(s, castBOItemsToPOItems(value));

                continue;
            }

            type.SetValue(s, value);
        }
        return (S)s;
    }

    public static ObservableCollection<PO.OrderItem> castBOItemsToPOItems(object BOlist)
    {
        return new ObservableCollection<PO.OrderItem>((from item
                                                       in (IEnumerable<BO.OrderItem>)BOlist
                                                       select cast<PO.OrderItem, BO.OrderItem>(item)).ToList());
    }

    public static List<BO.OrderItem> castPOItemsToBOItems(object POlist)
    {
       return (from item
               in (ObservableCollection<PO.OrderItem>)POlist
               select cast<BO.OrderItem, PO.OrderItem>(item) ).ToList();
    }



    public static void castCart(BO.Cart boCart,PO.Cart poCart)
    {
        PO.Cart newCart = PLUtils.cast<PO.Cart, BO.Cart>(boCart);
        poCart.Items = newCart.Items;
        poCart.TotalPrice = newCart.TotalPrice;
    }
}
