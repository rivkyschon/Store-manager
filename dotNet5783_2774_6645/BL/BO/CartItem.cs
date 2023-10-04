using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class CartItem
{
    public int ID { get; set; }
    public int ProductID { get; set; }
    public int UserID { get; set; }
    public int Amount { get; set; }
}
