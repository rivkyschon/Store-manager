using DO;
using Dal;
using System.Xml.Serialization;

namespace IntilizeXmlFile;
public class Program
{

    static void Main()
    {
        //using reflection (call static constructor)
        Type staticClassInfo = typeof(Dal.DataSource);
        var staticClassConstructorInfo = staticClassInfo.TypeInitializer;
        staticClassConstructorInfo?.Invoke(null, null);

        List<Product> PrdouctList = DataSource.ProductList;
        List<DO.Order> OrderList = DataSource.OrderList;
        List<OrderItem> OrderItemList = DataSource.OrderItemList;
        List<DO.User> UserList = new() { new DO.User() { Name = "Rivky", Password = "1234", Email = "Rizel", Address = "aaa", ID = 200000 } };

        StreamWriter wProduct = new(@"..\..\..\..\..\xml\Product.xml");
        XmlSerializer serProduct = new(typeof(List<Product>));
        serProduct.Serialize(wProduct, PrdouctList);
        wProduct.Close();

        StreamWriter wOrder = new(@"..\..\..\..\..\xml\Order.xml");
        XmlSerializer serOrder = new(typeof(List<DO.Order>));
        serOrder.Serialize(wOrder, OrderList);
        wOrder.Close();

        StreamWriter wOrderItem = new(@"..\..\..\..\..\xml\OrderItem.xml");
        XmlSerializer serOrderItem = new(typeof(List<OrderItem>));
        serOrderItem.Serialize(wOrderItem, OrderItemList);
        wOrderItem.Close();

        StreamWriter wUser = new(@"..\..\..\..\..\xml\User.xml");
        XmlSerializer serUser = new(typeof(List<DO.User>));
        serUser.Serialize(wUser, UserList);
        wUser.Close();
    }
}