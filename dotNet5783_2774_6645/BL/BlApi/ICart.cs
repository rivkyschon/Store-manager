using BO;
using System.Runtime.CompilerServices;

namespace BlApi;

public interface ICart
{
    public Cart AddToCart(Cart? cart, int productId, bool isRegistered = false);

    public Cart updateAmount(Cart cart, int productId, int newAmount, bool isRegistered = false);

    public void confirmOrder(Cart cart, bool isRegistered = false);

    public Cart GetCart(int userId);
}

