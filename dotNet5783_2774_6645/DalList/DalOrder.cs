using DalApi;
using DO;
using System.Runtime.CompilerServices;

namespace Dal;

internal class DalOrder : IOrder
{

    /// <summary>
    /// create order
    /// </summary>
    /// <param name="order">the new order</param>
    /// <returns> id of the order</returns>
    /// 
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(Order o)
    {
        o.ID = DataSource.Config.OrderID;
        DataSource.OrderList.Add(o);
        return o.ID;

    }

    /// <summary>
    ///  Deletes order by given id
    /// </summary>
    /// <param name="id"> Id of order to delete </param>
    /// <exception cref="Exception"> No order found with the given id </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        if (!DataSource.OrderList.Remove(DataSource.OrderList.Find(o => o.ID == id)))
            throw new ItemNotFound("could not delete order");
    }

    /// <summary>
    /// Updates an order
    /// </summary>
    /// <param name="updateOrder"> The updated order </param>
    /// <exception cref="Exception"> No order with the given id found </exception>


    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(Order o)
    {
        int idx = DataSource.OrderList.FindIndex(pr => pr.ID == o.ID);
        if (idx >= 0) DataSource.OrderList[idx] = o;
        else
            throw new ItemNotFound("could not update order");
    }

    /// <summary>
    /// returns all orders
    /// </summary>
    /// <returns> all orders in system </returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<Order>? GetList(Func<Order, bool>? func = null)
    {
        IEnumerable<Order> i = (IEnumerable<Order>)DataSource.OrderList;
        return (func == null ? i : i.Where(func));
    }


    /// <summary>
    /// functiod receives id if order and returns the orders details
    /// </summary>
    /// <param name="id"> id of specific order </param>
    /// <returns> order details of given id </returns>
    /// <exception cref="Exception"> no order with requested id found </exception>


    [MethodImpl(MethodImplOptions.Synchronized)]
    public Order Get(Func<Order, bool> func)
    {
        IEnumerable<Order> o = (IEnumerable<Order>)DataSource.OrderList;
        return o.Where(func).Count() != 0 ? o.Where(func).First() : throw new ItemNotFound("order not found");
    }
}

