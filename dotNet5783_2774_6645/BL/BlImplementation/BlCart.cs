using BlApi;
using BO;
using DO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace BlImplementation;

internal class BlCart : ICart
{

    private DalApi.IDal dal = DalApi.Factory.Get() ?? throw new Exception("dal api not found");

    /// <summary>
    /// checks if email is valid
    /// </summary>
    /// <param name="email"></param>
    /// <returns> true or false </returns>
    private bool IsValidEmail(string email)
    {
        Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        return regex.IsMatch(email);
    }
    private void addToCartDal(BO.Cart? cart, int productID)
    {
        DO.CartItem cartItem = new();
        cartItem.ProductID = productID;
        cartItem.Amount = 1;
        cartItem.UserID = cart?.UserID ?? throw new BlNullValueException();
        dal.CartItem.Add(cartItem);
    }

    private void confirmOrderDal(BO.Cart? cart)
    {
        lock (dal)
            dal.CartItem.Delete(c => c.UserID == cart.UserID);
    }


    [MethodImpl(MethodImplOptions.Synchronized)]
    public BO.Cart GetCart(int userId)
    {
        BO.Cart cart = new();
        try
        {
            IEnumerable<DO.CartItem> cartItems;
            BO.User userDetails;
            List<BO.OrderItem> orderItems;
            if (userId < 0) throw new BlInvalideData();
            lock (dal)
            {
                cartItems = dal.CartItem.GetList(o => o.UserID == userId) ?? throw new NoEntitiesFound();
                userDetails = BlUtils.cast<BO.User, DO.User>(dal.User.Get(i => i.ID == userId));
                orderItems = (from item in cartItems
                              let p = dal.Product.Get(o => o.ID == item.ProductID)
                              select new BO.OrderItem { ProductID = item.ProductID, Amount = item.Amount, Name = p.Name, Price = p.Price, TotalPrice = p.Price * item.Amount }).ToList();
            }
            cart.UserID = userId;
            cart.Items = orderItems;
            cart.CustomerName = userDetails.Name;
            cart.CustomerEmail = userDetails.Email;
            cart.CustomerAddress = userDetails.Address;
        }
        catch (DalApi.ItemNotFound e)
        {
            throw new BlIdNotFound(e);
        }
        return cart;
    }

    /// <summary>
    ///  adds new item to cart
    /// </summary>
    /// <param name="cart"> users cart </param>
    /// <param name="productId"> id of product to add to cart </param>
    /// <returns> updated cart </returns>
    /// <exception cref="BlOutOfStockException"> item not in stock </exception>
    /// <exception cref="BlIdNotFound"> product ID is invalid </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public BO.Cart AddToCart(BO.Cart? cart, int productId, bool isRegistered = false)
    {
        try
        {
            if (isRegistered) addToCartDal(cart, productId);

            DO.Product p = dal.Product.Get(p => p.ID == productId);
            List<BO.OrderItem> items = new List<BO.OrderItem>();
            items = cart.Items.ToList();
            if (p.Amount < 1) throw new BlOutOfStockException();

            if (cart.Items.ToList().Exists(i => i?.ProductID == productId)) throw new BlItemAlreadyInCart();

            BO.OrderItem oItem = BlUtils.cast<BO.OrderItem, DO.Product>(p);
            oItem.ProductID = p.ID;
            oItem.Amount = 1;
            oItem.TotalPrice = oItem.Price;
            items.Add(oItem);
            items.Sort((p1, p2) => p1.ProductID - p2.ProductID);
            cart.Items = items;
            cart.TotalPrice = cart.TotalPrice + oItem.TotalPrice;
            return cart;
        }
        catch (DalApi.ItemNotFound e)
        {
            throw new BlIdNotFound(e);
        }
    }

    /// <summary>
    ///  confirms order and sends carts details to datasource
    /// </summary>
    /// <param name="cart"> users cart </param>
    /// <param name="name"> users name</param>
    /// <param name="email"> users email</param>
    /// <param name="address"> users address </param>
    /// <exception cref="BlOutOfStockException"> item out of stock </exception>
    /// <exception cref="BlNegativeAmountException"> cannot order negative amount </exception>
    /// <exception cref="BlNullValueException"> user details missing </exception>
    /// <exception cref="BlInvalidEmailException"> invalid email </exception>
    /// <exception cref="BlIdNotFound"> id does not exist </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void confirmOrder(BO.Cart? cart, bool isRegistered = false)
    {
        try
        {
            if (isRegistered)
                confirmOrderDal(cart);
            if (cart?.CustomerName == "" || cart?.CustomerEmail == "" || cart?.CustomerAddress == "")
                throw new BlNullValueException();
            if (!IsValidEmail(cart?.CustomerEmail ?? throw new BlNullValueException()))
                throw new BlInvalidEmailException();

            cart?.Items?.ToList().ForEach(i =>
            {
                if (dal.Product.Get(p => p.ID == i?.ProductID).Amount < i?.Amount) throw new BlOutOfStockException();
                else if (i?.Amount < 0) throw new BlNegativeAmountException();
            });

            DO.Order order = BlUtils.cast<DO.Order, BO.Cart>(cart);
            order.OrderDate = DateTime.Now;
            int orderId = dal.Order.Add(order);

            foreach (BO.OrderItem? item in cart.Items ?? throw new BlNullValueException())
            {
                DO.OrderItem oItem = BlUtils.cast<DO.OrderItem, BO.OrderItem>(item ?? throw new BlNullValueException());
                oItem.OrderID = orderId;
                dal.OrderItem.Add(oItem);
                DO.Product product = dal.Product.Get(p => p.ID == oItem.ProductID);
                product.Amount = product.Amount - oItem.Amount;
                dal.Product.Update(product);
            }
        }
        catch (DalApi.ItemNotFound e)
        {
            throw new BlIdNotFound(e);
        }
    }

    /// <summary>
    ///  updates amount of product in users cart
    /// </summary>
    /// <param name="cart"> users cart </param>
    /// <param name="productId"> id of product to update amount</param>
    /// <param name="newAmount"> the new amount to update in the order </param>
    /// <returns> updated cart </returns>
    /// <exception cref="BlIdNotFound"> id of product is invalid </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public BO.Cart updateAmount(BO.Cart cart, int productId, int newAmount, bool isRegistered = false)
    {
        try
        {
            if (isRegistered)
                updateAmountDal(cart, productId, newAmount);
            BO.Cart newCart = cart;
            List<BO.OrderItem?> x = cart.Items.ToList();
            newCart.Items = x;
            DO.Product p;
            lock (dal)
                p = dal.Product.Get(p => p.ID == productId);

            var orderItem = from item in cart?.Items
                            where item?.ProductID == productId
                            select item;

            BO.OrderItem oi = orderItem.FirstOrDefault() ?? throw new NoEntitiesFound();
            if (oi.Amount + p.Amount < newAmount) throw new BlInvalidAmount();

            List<BO.OrderItem?> tempList = cart.Items.ToList();
            tempList.Remove(oi);
            cart.Items = tempList;
            cart.TotalPrice -= oi.TotalPrice;

            if (!newAmount.Equals(0))
            {
                oi.Amount = newAmount;
                oi.TotalPrice = p.Price * newAmount;
                List<BO.OrderItem?> lst = cart.Items.ToList();
                lst.Add(oi);
                lst.Sort((p1, p2) => p1.ProductID - p2.ProductID);
                cart.Items = lst;
                cart.TotalPrice += oi.TotalPrice;
            }
            return cart;
        }

        catch (DalApi.ItemNotFound e)
        {
            throw new BlIdNotFound(e);
        }
    }

    private void updateAmountDal(Cart cart, int productID, int newAmount)
    {
        DO.CartItem cartItem = new();
        cartItem.ProductID = productID;
        cartItem.Amount = newAmount;
        lock (dal)
            cartItem.ID = dal.CartItem.Get(c => c.ProductID == productID && c.UserID == cart.UserID).ID;
        cartItem.UserID = cart?.UserID ?? throw new BlNullValueException();
        dal.CartItem.Update(cartItem);
    }
}

