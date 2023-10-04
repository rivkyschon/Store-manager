using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface ICartItem: ICrud<DO.CartItem>
{
    public void Delete(Func<DO.CartItem, bool> f);

}
