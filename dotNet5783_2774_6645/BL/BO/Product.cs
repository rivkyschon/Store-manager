namespace BO;

public class Product
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public eCategory? Category { get; set; }
    public int InStock { get; set; }
    public string? Image { get; set; }
    public override string ToString() =>
$@"|  {ID}  |   {Name}    |  {Category}  |  {Price}   |   {InStock}   |
 ------------------------------------------------------------";
}

