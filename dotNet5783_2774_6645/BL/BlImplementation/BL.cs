using BlApi;

namespace BlImplementation;

sealed public class Bl : IBl
{
    public ICart Cart =>  new BlCart();

    public IProduct product =>  new BlProduct();
    public IOrder order =>  new BlOrder();
    public IUser user =>  new BlUser();
}

