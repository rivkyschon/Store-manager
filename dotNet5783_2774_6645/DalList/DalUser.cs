using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal;

internal class DalUser : IUser
{
    public int Add(User t)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public User Get(Func<User, bool> func)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User>? GetList(Func<User, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public void Update(User t)
    {
        throw new NotImplementedException();
    }
}
