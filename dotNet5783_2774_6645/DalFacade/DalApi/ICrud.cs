using System.Runtime.CompilerServices;

namespace DalApi;

public interface ICrud<T>
{
    public int Add(T t);

    public void Delete(int id);

    public void Update(T t);

    public IEnumerable<T>? GetList(Func<T?,bool>? func=null);

    public T? Get(Func<T?, bool> func);

}

