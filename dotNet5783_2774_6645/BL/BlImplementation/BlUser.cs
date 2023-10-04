using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using DalApi;

namespace BlImplementation;

public class BlUser : BlApi.IUser
{
    private DalApi.IDal dal = DalApi.Factory.Get() ?? throw new BlNullValueException();
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int AddUser(User u)
    {
        lock (dal)
        {
            return dal.User.Add(BlUtils.cast<DO.User, BO.User>(u));
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public int IsRegistered(string email, string pass)
    {
        try
        {
            DO.User user;
            lock (dal)
            {
                user = dal.User.Get(u => u.Email == email);
            }
            if (user.Password == pass) return user.ID;
        }
        catch (ItemNotFound e)
        {
            throw new BlIdNotFound(e);
        }
        return 0;
    }


    [MethodImpl(MethodImplOptions.Synchronized)]
    public void UpdateUser(User u)
    {
        lock (dal)
        {
            dal.User.Update(BlUtils.cast<DO.User, BO.User>(u));
        }
    }
}
