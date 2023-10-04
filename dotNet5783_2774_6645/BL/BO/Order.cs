namespace BO;

public class Order
{
    public int ID { set; get; }
    public string? CustomerName { set; get; }
    public string? CustomerEmail { set; get; }
    public string? CustomerAddress { set; get; }
    public DateTime? OrderDate { set; get; }
    public OrderStatus? Status { set; get; }
    public DateTime? ShipDate { set; get; }
    public DateTime? DeliveryDate { set; get; }
    public IEnumerable<OrderItem?>? Items { set; get; }
    public double TotalPrice { set; get; }

    public override string ToString() =>
    $@"|  {ID}   |   {CustomerName}   |    {CustomerEmail}   |   {CustomerAddress}  |   {OrderDate}   |  {ShipDate}  |  {DeliveryDate}  |{Status}|     {TotalPrice}     |
 ------------------------------------------------------------------------------------------------------------------------------------------------------";
}


