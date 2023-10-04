using DO;


namespace DalApi;
public interface IDal
{
    public IProduct Product { get => Product; }
    public IOrder Order { get => Order; }
    public IOrderItem OrderItem { get => OrderItem; }
    public IUser User { get; }
    public ICartItem CartItem { get; }
}
