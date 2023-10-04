namespace BO;

public class Cart
{
    public string? CustomerName { set; get; }
    public string? CustomerEmail { set; get; }
    public string? CustomerAddress { set; get; }
    public IEnumerable<OrderItem?>? Items { set; get; }
    public double TotalPrice { set; get; }
    public int? UserID { set; get; }
}


