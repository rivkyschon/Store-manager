namespace BO;
public class ProductForList
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public eCategory? Category { get; set; }
    public string? Image { get; set; }

    public override string ToString() =>
    $@"|  {ID}  |   {Name}    |  {Category}  |  {Price}   |
 ----------------------------------------------";
}


