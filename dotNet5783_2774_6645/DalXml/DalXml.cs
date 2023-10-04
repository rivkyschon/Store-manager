using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal;

sealed public class DalXml : IDal
{
    static private Lazy<DalXml>? instance = null;
    public static IDal Instance { get => GetInstance(); }

    public IProduct Product { get; } = new Dal.Product();
    public IOrder Order { get; } = new Dal.Order();
    public IOrderItem OrderItem { get; } = new Dal.OrderItem();
    public IUser User { get; } = new Dal.User();

    public ICartItem CartItem => new Dal.CartItem();

    private DalXml() { }
    public static DalXml GetInstance()
    {
        lock (instance ??= new Lazy<DalXml>(() => new DalXml()))
        {


            return instance.Value;
        }

    }
}