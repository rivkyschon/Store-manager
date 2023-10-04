// See https://aka.ms/new-console-template for more information
using DO;
using Dal;
using DalApi;

namespace DalTest;

public class Program
{

    public static IDal Dal = DalApi.Factory.Get() ?? throw new nullValueException();
    static void Main()
    {

        //using reflection (call static constructor)
        Type staticClassInfo = typeof(Dal.DataSource);
        var staticClassConstructorInfo = staticClassInfo.TypeInitializer ?? throw new nullValueException();
        staticClassConstructorInfo.Invoke(null, null);

        int choice = 0;
        do
        {
            //try
            //{
                Console.WriteLine("enter: \n 1 for product \n 2 for orders \n 3 for orders items \n 0 to exit");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        CRUDProduct();
                        break;
                    case 2:
                        CRUDOrder();
                        break;
                    case 3:
                        CRUDOrderItem();
                        break;
                    case 4:
                        CrudUser();
                        break;
                    default:
                        Console.WriteLine("incorrect input");
                        break;
                }
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine("{0} Exception caught.", e.Message);
            //}
        } while (choice != 0);
    }

    private static void CrudUser()
    { 
        User user = new User();
        user.Name = "Rivky";
        user.Email = "Rizel";
        user.Address = "AAA";
        user.Email = "AAA";
        user.ID = 200000;
        user.Password = "1234";
        Dal.User.Add(user);
    }

    private static void CRUDOrder()
    {
        string? s = "0";
        do
        {
            Console.WriteLine("enter: \n a to add order \n b to display orders by id \n c to display list of orders \n d to update order \n e to erase order from list \n 0 to return main menu");
            s = Console.ReadLine();
            switch (s)
            {
                case "a":
                    addOrder();
                    break;
                case "b":
                    displayOrder();
                    break;
                case "c":
                    displayOrderList();
                    break;
                case "d":
                    updateOrder();
                    break;
                case "e":
                    deleteOrder();
                    break;
            }
        } while (s != "0");

    }
    private static void CRUDOrderItem()
    {
        string? s = "0";
        do
        {
            Console.WriteLine("enter: \n a to add order item \n b to display order items by order id \n c to display list of all ordered items \n d to display ordered item by product id and order id \n e to update orders item \n f to erase order item from list \n 0 to return main menu");

            s = Console.ReadLine();
            switch (s)
            {
                case "a":
                    addOrderItem();
                    break;
                case "b":
                    displayOrderItems();
                    break;
                case "c":
                    displayAllItems();
                    break;
                case "d":
                    displayItem();
                    break;
                case "e":
                    updateOrderItem();
                    break;
                case "f":
                    deleteOrderItem();
                    break;
            }
        } while (s != "0");

    }
    private static void CRUDProduct()
    {

        string? s = "0";
        do
        {
            Console.WriteLine("enter: \n a to add product \n b to display product by id \n c to display list of products \n d to update product \n e to erase product from list \n 0 to return main menu");

            s = Console.ReadLine();
            switch (s)
            {
                case "a":
                    addProduct();
                    break;
                case "b":
                    displayProduct();
                    break;
                case "c":
                    displayProductList();
                    break;
                case "d":
                    updateProduct();
                    break;
                case "e":
                    deleteProduct();
                    break;
            }
        } while (s != "0");
    }

    /// <summary>
    /// accepts order details from user
    /// </summary>
    /// <returns>order object</returns>
    private static Order createOrder()
    {
        Order newOrder = new Order();
        Console.WriteLine("enter name:");
        newOrder.CustomerName = Console.ReadLine();
        Console.WriteLine("enter email:");
        newOrder.CustomerEmail = Console.ReadLine();
        Console.WriteLine("enter adress:");
        newOrder.CustomerAddress = Console.ReadLine();
        newOrder.OrderDate = DateTime.MinValue;
        TimeSpan ShipDate = TimeSpan.FromDays(2);
        TimeSpan deliveryDate = TimeSpan.FromDays(20);
        newOrder.ShipDate = newOrder.OrderDate + ShipDate;
        newOrder.DeliveryDate = newOrder.OrderDate + deliveryDate;
        return newOrder;

    }
    private static void addOrder()
    {
        Order newOrder = createOrder();
        Dal.Order.Add(newOrder);
    }

    private static void displayOrder()
    {
        Console.WriteLine("enter id:");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("|    ID     |   NAME  |  EMAIL   | ADRESS |        ORDER DATE       |        SHIP DATE      |      DELIVERY DATE    |");
        Console.WriteLine("|___________|_________|__________|________|_________________________|_______________________|_______________________|");
        Console.WriteLine("|           |         |          |        |                         |                       |                       |");
        Console.WriteLine(Dal.Order.Get(p => p.ID == id));
    }

    private static void displayOrderList()
    {
        IEnumerable<Order>? orderList = Dal.Order.GetList();
        Console.WriteLine("|    ID     |   NAME  |  EMAIL   | ADRESS |        ORDER DATE       |        SHIP DATE      |      DELIVERY DATE    |");
        Console.WriteLine("|___________|_________|__________|________|_________________________|_______________________|_______________________|");
        Console.WriteLine("|           |         |          |        |                         |                       |                       |");
        foreach (Order item in orderList ?? throw new nullValueException())
            Console.WriteLine(item);

    }

    private static void updateOrder()
    {
        int id;
        Order newOrder = createOrder();
        Console.WriteLine("enter order ID:");
        int.TryParse(Console.ReadLine(), out id);
        newOrder.ID = id;
        Dal.Order.Update(newOrder);
    }

    private static void deleteOrder()
    {
        int id;
        Console.WriteLine("enter id:");
        int.TryParse(Console.ReadLine(), out id);
        Dal.Order.Delete(id);
    }

    /// <summary>
    /// accepts product details from user
    /// </summary>
    /// <returns>product object</returns>
    private static Product createProduct()
    {
        Product newProduct = new Product();
        Console.WriteLine("enter name:");
        newProduct.Name = Console.ReadLine();
        Console.WriteLine("enter price:");
        int.TryParse(Console.ReadLine(), out int price);
        newProduct.Price = price;
        Console.WriteLine("enter category:");
        int.TryParse(Console.ReadLine(), out int category);
        newProduct.Category = (eCategory)category;
        Console.WriteLine("enter amount in stock:");
        int.TryParse(Console.ReadLine(), out int inStock);
        newProduct.Amount = inStock;
        return newProduct;

    }
    private static void addProduct()
    {
        Product newProduct = createProduct();
        Dal.Product.Add(newProduct);
    }

    private static void displayProduct()
    {
        Console.WriteLine("enter id:");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("|    ID    |       NAME       | CATEGORY | PRICE | IN STOCK |");
        Console.WriteLine("|__________|__________________|__________|_______|__________|");
        Console.WriteLine("|          |                  |          |       |          |");
        Console.WriteLine(Dal.Product.Get(p => p.ID == id));
    }

    private static void displayProductList()
    {
        IEnumerable<Product>? productList = Dal.Product.GetList();
        Console.WriteLine("|    ID    |       NAME       | CATEGORY | PRICE | IN STOCK |");
        Console.WriteLine("|__________|__________________|__________|_______|__________|");
        Console.WriteLine("|          |                  |          |       |          |");
        foreach (Product item in productList ?? throw new nullValueException())
            Console.WriteLine(item);
    }

    private static void updateProduct()
    {
        Product newProduct = createProduct();
        Console.WriteLine("enter Product ID");
        int.TryParse(Console.ReadLine(), out int id);
        newProduct.ID = id;
        Dal.Product.Update(newProduct);
    }

    private static void deleteProduct()
    {
        Console.WriteLine("enter id:");
        int.TryParse(Console.ReadLine(), out int id);
        Dal.Product.Delete(id);
    }


    /// <summary>
    /// accepts order item details from user
    /// </summary>
    /// <returns>order item object</returns>
    private static OrderItem createOrderItem()
    {
        OrderItem newOrderItem = new OrderItem();
        Console.WriteLine("enter product id:");
        int.TryParse(Console.ReadLine(), out int productId);
        newOrderItem.ProductID = productId;
        Console.WriteLine("enter order id:");
        int.TryParse(Console.ReadLine(), out int orderId);
        newOrderItem.OrderID = orderId;
        Console.WriteLine("enter price:");
        int.TryParse(Console.ReadLine(), out int price);
        newOrderItem.Price = price;
        Console.WriteLine("enter amount:");
        int.TryParse(Console.ReadLine(), out int amount);
        newOrderItem.Amount = amount;
        return newOrderItem;

    }
    private static void addOrderItem()
    {
        OrderItem newOrderItem = createOrderItem();
        Dal.OrderItem.Add(newOrderItem);
    }

    private static void displayOrderItems()
    {
        Console.WriteLine("enter order id:");
        int.TryParse(Console.ReadLine(), out int id);
        IEnumerable<OrderItem> orderItems = Dal.OrderItem.GetList(o => o.ID == id) ?? throw new nullValueException();
        Console.WriteLine("| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |");
        Console.WriteLine("|____________|____________|___________|__________|");
        Console.WriteLine("|            |            |           |          |");
        foreach (OrderItem item in orderItems)
            Console.WriteLine(item);

    }

    private static void displayAllItems()
    {
        IEnumerable<OrderItem> orderList = Dal.OrderItem.GetList() ?? throw new nullValueException();
        Console.WriteLine("| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |");
        Console.WriteLine("|____________|____________|___________|__________|");
        Console.WriteLine("|            |            |           |          |");
        foreach (OrderItem item in orderList)
            Console.WriteLine(item);
    }

    private static void displayItem()
    {
        Console.WriteLine("enter  id:");
        int.TryParse(Console.ReadLine(), out int Id);
        Console.WriteLine("| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |");
        Console.WriteLine("|____________|____________|___________|__________|");
        Console.WriteLine("|            |            |           |          |");
        Console.WriteLine(Dal.OrderItem.Get(o => o.ID == Id));
    }

    private static void updateOrderItem()
    {
        OrderItem newOrderItem = createOrderItem();
        Dal.OrderItem.Update(newOrderItem);
    }

    private static void deleteOrderItem()
    {
        Console.WriteLine("enter id:");
        int.TryParse(Console.ReadLine(), out int Id);
        Dal.OrderItem.Delete(Id);
    }

}

/*
==================================================================================

Run Example stage1

==================================================================================

enter 1 for product , 2 for orders, 3 for orders items, 0 to exit
2
enter a to add order , b to display orders by id , c to display list of orders, d to update order , e to erase order from list, 0 to return main menu
b
enter id:
500008
|    ID     |   NAME  |  EMAIL   | ADRESS |        ORDER DATE       |        SHIP DATE      |      DELIVERY DATE    |
|___________|_________|__________|________|_________________________|_______________________|_______________________|
|           |         |          |        |                         |                       |                       |
|  500008   |   ccc   |    iii   |   fff  |   05/09/2020 00:00:00   |  07/09/2020 00:00:00  |  25/09/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
enter a to add order , b to display orders by id , c to display list of orders, d to update order , e to erase order from list, 0 to return main menu
3
enter a to add order , b to display orders by id , c to display list of orders, d to update order , e to erase order from list, 0 to return main menu
b
enter id:
500008
|    ID     |   NAME  |  EMAIL   | ADRESS |        ORDER DATE       |        SHIP DATE      |      DELIVERY DATE    |
|___________|_________|__________|________|_________________________|_______________________|_______________________|
|           |         |          |        |                         |                       |                       |
|  500008   |   ccc   |    iii   |   fff  |   05/09/2020 00:00:00   |  07/09/2020 00:00:00  |  25/09/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
enter a to add order , b to display orders by id , c to display list of orders, d to update order , e to erase order from list, 0 to return main menu
c
|    ID     |   NAME  |  EMAIL   | ADRESS |        ORDER DATE       |        SHIP DATE      |      DELIVERY DATE    |
|___________|_________|__________|________|_________________________|_______________________|_______________________|
|           |         |          |        |                         |                       |                       |
|  500000   |   aaa   |    ggg   |   ddd  |   26/06/2022 00:00:00   |  28/06/2022 00:00:00  |  16/07/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500001   |   bbb   |    hhh   |   ddd  |   16/12/2021 00:00:00   |  18/12/2021 00:00:00  |  05/01/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500002   |   bbb   |    ggg   |   fff  |   16/08/2022 00:00:00   |  18/08/2022 00:00:00  |  05/09/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500003   |   ccc   |    ggg   |   eee  |   16/06/2020 00:00:00   |  18/06/2020 00:00:00  |  06/07/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500004   |   bbb   |    ggg   |   fff  |   23/08/2021 00:00:00   |  25/08/2021 00:00:00  |  12/09/2021 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500005   |   aaa   |    ggg   |   fff  |   13/04/2020 00:00:00   |  15/04/2020 00:00:00  |  03/05/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500006   |   aaa   |    ggg   |   fff  |   06/05/2021 00:00:00   |  08/05/2021 00:00:00  |  26/05/2021 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500007   |   aaa   |    ggg   |   fff  |   01/05/2020 00:00:00   |  03/05/2020 00:00:00  |  21/05/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500008   |   ccc   |    iii   |   fff  |   05/09/2020 00:00:00   |  07/09/2020 00:00:00  |  25/09/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500009   |   aaa   |    hhh   |   ddd  |   21/11/2020 00:00:00   |  23/11/2020 00:00:00  |  11/12/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500010   |   aaa   |    ggg   |   fff  |   01/07/2022 00:00:00   |  03/07/2022 00:00:00  |  21/07/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500011   |   ccc   |    iii   |   fff  |   04/01/2021 00:00:00   |  06/01/2021 00:00:00  |  24/01/2021 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500012   |   ccc   |    hhh   |   ddd  |   28/10/2022 00:00:00   |  30/10/2022 00:00:00  |  17/11/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500013   |   ccc   |    iii   |   eee  |   05/03/2020 00:00:00   |  07/03/2020 00:00:00  |  25/03/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500014   |   ccc   |    ggg   |   ddd  |   13/05/2022 00:00:00   |  15/05/2022 00:00:00  |  02/06/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500015   |   bbb   |    iii   |   fff  |   28/02/2021 00:00:00   |  02/03/2021 00:00:00  |  20/03/2021 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500016   |   ccc   |    ggg   |   ddd  |   20/01/2022 00:00:00   |  22/01/2022 00:00:00  |  09/02/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500017   |   ccc   |    ggg   |   ddd  |   11/05/2022 00:00:00   |  13/05/2022 00:00:00  |  31/05/2022 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500018   |   aaa   |    ggg   |   eee  |   10/01/2021 00:00:00   |  12/01/2021 00:00:00  |  30/01/2021 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
|  500019   |   ccc   |    ggg   |   fff  |   13/10/2020 00:00:00   |  15/10/2020 00:00:00  |  02/11/2020 00:00:00  |
 --------------------------------------------------------------------------------------------------------------------
enter a to add order , b to display orders by id , c to display list of orders, d to update order , e to erase order from list, 0 to return main menu
d
enter name:
aa
enter email:
aaa
enter adress:
aaaaa
enter order ID
50018
 could not update order  Exception caught.
enter 1 for product , 2 for orders, 3 for orders items, 0 to exit
3
enter a to add order item, b to display order items by order id , c to display list of all ordered items,d to display ordered item by product id and order id, e to update orders item , f to erase order item from list, 0 to return main menu
b
enter order id:
500008
| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |
|____________|____________|___________|__________|
|            |            |           |          |
|   100008   |   500008   |     91    |     8    |
-------------------------------------------------
|   100008   |   500008   |     91    |     3    |
-------------------------------------------------
enter a to add order item, b to display order items by order id , c to display list of all ordered items,d to display ordered item by product id and order id, e to update orders item , f to erase order item from list, 0 to return main menu
d
enter order id:
500016
enter product id:
100016
| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |
|____________|____________|___________|__________|
|            |            |           |          |
 requested item  not found  Exception caught.
enter 1 for product , 2 for orders, 3 for orders items, 0 to exit
3
enter a to add order item, b to display order items by order id , c to display list of all ordered items,d to display ordered item by product id and order id, e to update orders item , f to erase order item from list, 0 to return main menu
c
| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |
|____________|____________|___________|__________|
|            |            |           |          |
|   100000   |   500000   |     82    |     5    |
-------------------------------------------------
|   100001   |   500001   |     81    |     2    |
-------------------------------------------------
|   100002   |   500002   |     70    |     3    |
-------------------------------------------------
|   100003   |   500003   |     60    |     1    |
-------------------------------------------------
|   100004   |   500004   |     10    |     4    |
-------------------------------------------------
|   100005   |   500005   |     65    |     4    |
-------------------------------------------------
|   100006   |   500006   |     47    |     1    |
-------------------------------------------------
|   100007   |   500007   |     98    |     2    |
-------------------------------------------------
|   100008   |   500008   |     91    |     8    |
-------------------------------------------------
|   100009   |   500009   |     45    |     1    |
-------------------------------------------------
|   100000   |   500010   |     82    |     5    |
-------------------------------------------------
|   100001   |   500011   |     81    |     2    |
-------------------------------------------------
|   100002   |   500012   |     70    |     4    |
-------------------------------------------------
|   100003   |   500013   |     60    |     8    |
-------------------------------------------------
|   100004   |   500014   |     10    |     3    |
-------------------------------------------------
|   100005   |   500015   |     65    |     2    |
-------------------------------------------------
|   100006   |   500016   |     47    |     5    |
-------------------------------------------------
|   100007   |   500017   |     98    |     5    |
-------------------------------------------------
|   100008   |   500018   |     91    |     5    |
-------------------------------------------------
|   100009   |   500019   |     45    |     2    |
-------------------------------------------------
|   100000   |   500000   |     82    |     1    |
-------------------------------------------------
|   100001   |   500001   |     81    |     3    |
-------------------------------------------------
|   100002   |   500002   |     70    |     5    |
-------------------------------------------------
|   100003   |   500003   |     60    |     3    |
-------------------------------------------------
|   100004   |   500004   |     10    |     1    |
-------------------------------------------------
|   100005   |   500005   |     65    |     5    |
-------------------------------------------------
|   100006   |   500006   |     47    |     5    |
-------------------------------------------------
|   100007   |   500007   |     98    |     6    |
-------------------------------------------------
|   100008   |   500008   |     91    |     3    |
-------------------------------------------------
|   100009   |   500009   |     45    |     7    |
-------------------------------------------------
|   100000   |   500010   |     82    |     8    |
-------------------------------------------------
|   100001   |   500011   |     81    |     4    |
-------------------------------------------------
|   100002   |   500012   |     70    |     2    |
-------------------------------------------------
|   100003   |   500013   |     60    |     5    |
-------------------------------------------------
|   100004   |   500014   |     10    |     4    |
-------------------------------------------------
|   100005   |   500015   |     65    |     7    |
-------------------------------------------------
|   100006   |   500016   |     47    |     2    |
-------------------------------------------------
|   100007   |   500017   |     98    |     1    |
-------------------------------------------------
|   100008   |   500018   |     91    |     3    |
-------------------------------------------------
|   100009   |   500019   |     45    |     6    |
-------------------------------------------------
enter a to add order item, b to display order items by order id , c to display list of all ordered items,d to display ordered item by product id and order id, e to update orders item , f to erase order item from list, 0 to return main menu
d
enter order id:
500016
enter product id:
100006
| PRODUCT ID |  ORDER ID  |   PRICE   |  AMOUNT  |
|____________|____________|___________|__________|
|            |            |           |          |
|   100006   |   500016   |     47    |     5    |
-------------------------------------------------
enter a to add order item, b to display order items by order id , c to display list of all ordered items,d to display ordered item by product id and order id, e to update orders item , f to erase order item from list, 0 to return main menu
*/


