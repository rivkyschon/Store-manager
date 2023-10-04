using static BO.eCategory;
namespace BO;

public class ProductItem
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public eCategory? Category { get; set; }
    public string? Image { get; set; }
    public int Amount { get; set; }
   public bool InStock { get; set; }

    public override string ToString() =>
    $@"|  {ID}  |   {Name}    |  {Category}  |  {Price}   |   {Amount}   
 ------------------------------------------------------------------";
}

