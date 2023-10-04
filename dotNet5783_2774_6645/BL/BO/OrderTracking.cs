using BlApi;

namespace BO;

public class OrderTracking
{
    public int ID { get; set; }
    public OrderStatus? Status { get; set; }
    public List<(DateTime?, OrderStatus?)>? TrackList { get; set; } = new List<(DateTime?, OrderStatus?)>();
    public override string ToString()
    {
        string toString = $@"ID: {ID} "+"\n";

        foreach ((DateTime?, OrderStatus?) item in TrackList ?? throw new BlNullValueException())
        {
            toString += item.Item1 + " " + item.Item2 + "\n";
        }
        return toString;
    }

}

