using DO;
using DalApi;
using System.Runtime.CompilerServices;

namespace Dal;
internal class DalOrderItem : IOrderItem
{


    /// <summary>
    /// create new order item
    /// </summary>
    /// <param name="orderItem"> neworder item details </param>
    /// <returns> index of new order item </returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(OrderItem o)
    {
        DataSource.OrderItemList.Add(o);
        return (int)o.OrderID;
    }

    /// <summary>
    ///  deletes ordered item by product id and order id
    /// </summary>
    /// <param name="orderId"> Id of order with desired item </param>
    /// <param name="productId"> Id of product </param>
    /// <exception cref="Exception"> No such product in given order </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        if (!DataSource.OrderItemList.Remove(DataSource.OrderItemList.Find(o => o.ID == id)))
            throw new ItemNotFound("error can't delete order item");
    }


    /// <summary>
    /// Updates ordered item
    /// </summary>
    /// <param name="updateOrderItem"> Details of ordered item to update</param>
    /// <exception cref="Exception"> No order with given id found </exception>

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(OrderItem o)
    {
      
        int idx = DataSource.OrderItemList.FindIndex(pr => pr.ID == o.ID);
        if (idx >= 0) DataSource.OrderItemList[idx] = o;
        else
            throw new ItemNotFound("could not update order item");
    }

    /// <summary>
    /// returns all ordered items
    /// </summary>
    /// <returns> All ordered items </returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<OrderItem>? GetList(Func<OrderItem, bool>? func = null)
    {
        IEnumerable<OrderItem> i = DataSource.OrderItemList;
        return func==null?i: i.Where(func).ToList();
    }

    /// <summary>
    /// returns details of specific ordered item by ID
    /// </summary>
    /// <param name="orderId"> Id of order that desired item is in</param>
    /// <param name="productId"> Id of product </param>
    /// <returns> Details of ordered item </returns>
    /// <exception cref="Exception"> no order </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public OrderItem Get(Func<OrderItem, bool> func)
    {
        IEnumerable<OrderItem> o = (IEnumerable<OrderItem>)DataSource.OrderItemList;
        return o.Where(func) != null ? o.Where(func).First() : throw new ItemNotFound("order Item not found");
    }


}

