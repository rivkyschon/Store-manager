namespace BlApi;

public interface IBl
{
    public ICart Cart { get; }
    public IProduct product { get; }
    public IOrder order { get; }
    public IUser user { get; }
}

