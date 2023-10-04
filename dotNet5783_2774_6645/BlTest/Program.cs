using BlApi;
using BlImplementation;
using BO;

public class Program
{
    public static IBl BL = new Bl();
    public static Cart cart = new();


    //=========================================== MAIN ===================================================


    static void Main()
    {
        int choice = 0;
        do
        {
            User user = new User();
            user.Name = "Rivky";
            user.Email = "Rizel";
            user.Address = "AAA";
            user.Email = "ABC";
            user.ID = 200000;
            user.Password = "1234";
            BL.user.UpdateUser(user);
            Console.WriteLine("enter: \n 1 for product \n 2 for orders \n 3 for cart \n 0 to exit");
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
                    CRUDCart();
                    break;
                default:
                    Console.WriteLine("incorrect input");
                    break;
            }
        } while (choice != 0);
    }


    //=========================================== PRODUCT ======================================================

    /// <summary>
    /// Actions on a product
    /// </summary>
    private static void CRUDProduct()
    {

        string? s = "0";
        do
        {
            Console.WriteLine("enter: \n a to get product for manager \n b to get product to customer \n c to get product by id to customer  \n d to get product by id to manager  \n e to add product \n f to erase product from list \n g  to update product\n  0 to return main menu");

            s = Console.ReadLine();
            switch (s)
            {
                case "a":
                    getProductList();
                    break;
                case "b":
                    getProductItem();
                    break;
                case "c":
                    getProductForCustomer();
                    break;
                case "d":
                    getProductForManager();
                    break;
                case "e":
                    addProduct();
                    break;
                case "f":
                    deleteProduct();
                    break;
                case "g":
                    updateProduct();
                    break;
            }
        } while (s != "0");
    }

    /// <summary>
    /// get product list for manager
    /// </summary>
    private static void getProductList()
    {
        IEnumerable<ProductForList?> productList = BL.product.GetProductList();
        Console.WriteLine("|    ID    |       NAME       | CATEGORY | PRICE |");
        Console.WriteLine("|__________|__________________|__________|_______|");
        Console.WriteLine("|          |                  |          |       |");
        productList.ToList().ForEach(product => Console.WriteLine(product));
    }

    /// <summary>
    /// get product list for user
    /// </summary>
    private static void getProductItem()
    {
        IEnumerable<ProductItem?> productList = BL.product.GetProductItem();
        Console.WriteLine("|    ID    |       NAME       | CATEGORY | PRICE |   AMOUNT  |   IN STOCK |");
        Console.WriteLine("|__________|__________________|__________|_______|___________|____________|");
        Console.WriteLine("|          |                  |          |       |           |            |");
        productList.ToList().ForEach(product => Console.WriteLine(product));
    }

    /// <summary>
    /// get product by id for user
    /// </summary>
    private static void getProductForCustomer()
    {
        try
        {
            int id = displayProduct();
            Product p = BL.product.GetProductForCustomer(id);
            Console.WriteLine(p);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (BlInvalideData e)
        {
            Console.WriteLine(e.Message);
        }
    }


    /// <summary>
    /// get product by id for manager
    /// </summary>
    private static void getProductForManager()
    {
        try
        {
            int id = displayProduct();
            Product p = BL.product.GetProductForManager(id);
            Console.WriteLine(p);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (BlInvalideData e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// add product for a list of products
    /// </summary>
    private static void addProduct()
    {
        Product newProduct = createProduct();
        BL.product.AddProduct(newProduct);
    }

    private static void deleteProduct()
    {
        try
        {
            Console.WriteLine("enter id:");
            int.TryParse(Console.ReadLine(), out int id);
            BL.product.DeleteProduct(id);
        }
        catch (BlProductFoundInOrders e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// update product in a list of products
    /// </summary>
    private static void updateProduct()
    {
        try
        {
            Product newProduct = createProduct();
            Console.WriteLine("enter Product ID");
            int.TryParse(Console.ReadLine(), out int id);
            newProduct.ID = id;
            BL.product.UpdateProduct(newProduct);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (BlNullValueException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlInvalideData e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Receives product details from the manager
    /// </summary>
    /// <returns>details of product</returns>
    private static Product createProduct()
    {
        Product newProduct = new();
        Console.WriteLine("enter name:");
        newProduct.Name = Console.ReadLine();
        newProduct.ID = Dal.DataSource.Config.ProductID;
        Console.WriteLine("enter price:");
        int.TryParse(Console.ReadLine(), out int price);
        newProduct.Price = price;
        Console.WriteLine("enter category:");
        int.TryParse(Console.ReadLine(), out int category);
        newProduct.Category = (eCategory)category;
        Console.WriteLine("enter amount in stock:");
        int.TryParse(Console.ReadLine(), out int inStock);
        newProduct.InStock = inStock;
        return newProduct;

    }

    private static int displayProduct()
    {
        Console.WriteLine("enter id:");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("|    ID    |       NAME       | CATEGORY | PRICE | IN STOCK |");
        Console.WriteLine("|__________|__________________|__________|_______|__________|");
        Console.WriteLine("|          |                  |          |       |          |");
        return id;
    }


    //=========================================== ORDER ======================================================

    /// <summary>
    /// Actions on an order
    /// </summary>
    private static void CRUDOrder()
    {
        string? s = "0";
        do
        {
            Console.WriteLine("enter: \n a to get order for manager \n b to display orders by id \n c to update shiped date \n d to update dalivery date \n e to update order \n g to order tracking \n 0 to return main menu");
            s = Console.ReadLine();
            switch (s)
            {
                case "a":
                    displayOrderList();
                    break;
                case "b":
                    displayOrder();
                    break;
                case "c":
                    updateShipedDate();
                    break;
                case "d":
                    updateDeliveryDate();
                    break;
                case "e":
                    updateOrder();
                    break;
                case "g":
                    orderTracking();
                    break;
            }
        } while (s != "0");

    }

    private static void orderTracking()
    {
        try
        {
            Console.WriteLine("enter id:");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine(BL.order.OrderTracking(id));
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }

    }



    /// <summary>
    /// display order list 
    /// </summary>
    private static void displayOrderList()
    {
        IEnumerable<OrderForList?> orderList = BL.order.OrderList();
        Console.WriteLine("|    ID     |   NAME  |           STATUS         | AMOUNT |TOTAL PRICE|");
        Console.WriteLine("|___________|_________|__________________________|________|___________|");
        Console.WriteLine("|           |         |                          |        |           |");
        orderList.ToList().ForEach(o => Console.WriteLine(o));

    }

    /// <summary>
    /// displat order by id
    /// </summary>
    private static void displayOrder()
    {
        try
        {
            Console.WriteLine("enter id:");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("|    ID     |   NAME  |  EMAIL   | ADRESS |        ORDER DATE       |        SHIP DATE      |      DELIVERY DATE    |       STATUS      |  TOTAL PRICE  |");
            Console.WriteLine("|___________|_________|__________|________|_________________________|_______________________|_______________________|___________________|_______________|");
            Console.WriteLine("|           |         |          |        |                         |                       |                       |                   |               |");
            Console.WriteLine(BL.order.GetOrder(id));
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (BlInvalideData e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// update shiped date
    /// </summary>
    private static void updateShipedDate()
    {
        try
        {
            int id;
            Console.WriteLine("enter order ID:");
            int.TryParse(Console.ReadLine(), out id);
            BL.order.UpdateShipedOrder(id);
        }
        catch (BlInvalidStatusException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
    }

    /// <summary>
    /// update delivery date
    /// </summary>
    private static void updateDeliveryDate()
    {
        try
        {
            int id;
            Console.WriteLine("enter order ID:");
            int.TryParse(Console.ReadLine(), out id);
            BL.order.UpdateDeliveryOrder(id);
        }
        catch (BlInvalidStatusException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void updateOrder()
    {
        try
        {
            Console.WriteLine("enter order ID:");
            int.TryParse(Console.ReadLine(), out int id);
            BO.Order o = new();
            o.ID = id;
            List<BO.OrderItem> list = new();
            BO.OrderItem oItem = new();
            int choice = 0;
            do

            {
                Console.WriteLine("enter product ID:");
                int.TryParse(Console.ReadLine(), out int productId);
                oItem.ProductID = productId;
                Console.WriteLine("enter new amount:");
                int.TryParse(Console.ReadLine(), out int amount);
                oItem.Amount = amount;
                list.Add(oItem);
                Console.WriteLine("press 0 to stop any key to continue");
                int.TryParse(Console.ReadLine(), out choice);
            } while (choice != 0);

            o.Items = list;
            BL.order.UpdateOrder(o);
        }
        catch (BlInvalidAmount e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlNegativeAmountException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
    }



    //=========================================== CART ========================================================



    /// <summary>
    /// Actions on a cart
    /// </summary>
    private static void CRUDCart()
    {
        string? s = "0";
        do
        {
            Console.WriteLine("enter: \n a to add to cart \n b to update amount of item \n c to confirm order \n  0 to return main menu");

            s = Console.ReadLine();
            switch (s)
            {
                case "a":
                    addToCart();
                    break;
                case "b":
                    updateAmount();
                    break;
                case "c":
                    confirmOrder();
                    break;
            }
        } while (s != "0");

    }

    /// <summary>
    /// add product to the cart
    /// </summary>
    private static void addToCart()
    {
        try
        {
            Console.WriteLine("enter product ID:");
            int.TryParse(Console.ReadLine(), out int pId);
            cart = BL.Cart.AddToCart(cart, pId);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (BlOutOfStockException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlItemAlreadyInCart e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// confirms order and sends carts details to datasource
    /// </summary>
    private static void confirmOrder()
    {
        try
        {
            Console.WriteLine("enter name:");
            string? name = Console.ReadLine();
            Console.WriteLine("enter email:");
            string? email = Console.ReadLine();
            Console.WriteLine("enter address:");
            string? address = Console.ReadLine();
            cart.CustomerAddress = address;
            cart.CustomerEmail = email;
            cart.CustomerName = name;
            BL.Cart.confirmOrder(cart);
            cart = new Cart();
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (BlInvalidEmailException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlNullValueException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlNegativeAmountException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (BlOutOfStockException e)
        {
            Console.WriteLine(e.Message);
        }
    }


    /// <summary>
    /// update amount of product in the cart
    /// </summary>
    private static void updateAmount()
    {
        try
        {
            Console.WriteLine("enter product ID:");
            int.TryParse(Console.ReadLine(), out int pId);
            Console.WriteLine("enter new amount:");
            int.TryParse(Console.ReadLine(), out int amount);
            cart = BL.Cart.updateAmount(cart, pId, amount);
        }
        catch (BlIdNotFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }
        catch (NoEntitiesFound e)
        {
            Console.WriteLine(e.Message + e.InnerException);
        }

    }
}

