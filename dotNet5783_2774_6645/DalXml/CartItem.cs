using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DalApi;

namespace Dal;

public class CartItem : ICartItem
{

    static string cartItemSrc = @"..\..\xml\CartItem.xml";
    public XmlRootAttribute xRoot()
    {
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "ArrayOfCartItem";
        xRoot.IsNullable = true;
        return xRoot;
    }
    public int Add(DO.CartItem c)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.CartItem>), xRoot());
        StreamReader r = new(cartItemSrc);
        List<DO.CartItem>? lst = (List<DO.CartItem>?)ser.Deserialize(r);
        c.ID = lst?.Last().ID + 1 ?? throw new XMLFileNullExeption();
        lst?.Add(c);
        r.Close();
        StreamWriter w = new(cartItemSrc);
        ser.Serialize(w, lst);
        w.Close();
        return c.ID;
    }

    public void Delete(int id)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.CartItem>), xRoot());
        StreamReader r = new(cartItemSrc);
        List<DO.CartItem>? lst = (List<DO.CartItem>?)ser.Deserialize(r);
        lst?.Remove(lst.Where(p => p.ID == id).FirstOrDefault());
        r.Close();
        StreamWriter w = new(cartItemSrc);
        ser.Serialize(w, lst);
        w.Close();
    }

    public DO.CartItem Get(Func<DO.CartItem, bool> func)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.CartItem>), xRoot());
        StreamReader r = new(cartItemSrc);
        List<DO.CartItem>? lst = (List<DO.CartItem>?)ser.Deserialize(r);
        r.Close();
        return lst?.Where(func) != null ? lst.Where(func).First() : throw new ItemNotFound("");
    }

    public IEnumerable<DO.CartItem>? GetList(Func<DO.CartItem, bool>? func = null)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.CartItem>), xRoot());
        StreamReader r = new(cartItemSrc);
        List<DO.CartItem>? lst = (List<DO.CartItem>?)ser.Deserialize(r);
        r.Close();
        return (func == null ? lst : lst?.Where(func));
    }

    public void Update(DO.CartItem c)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.CartItem>), xRoot());
        StreamReader readFile = new(cartItemSrc);
        List<DO.CartItem>? lst = (List<DO.CartItem>?)ser.Deserialize(readFile) ?? throw new XMLFileNullExeption();
        int idx = lst.FindIndex(pr => pr.ID == c.ID);
        if (idx >= 0) lst[idx] = c;
        else
            throw new ItemNotFound("could not update product");
        readFile.Close();
        StreamWriter writeFile = new(cartItemSrc);
        ser.Serialize(writeFile, lst);
        writeFile.Close();
    }

    public void Delete(Func< DO.CartItem, bool> f)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.CartItem>), xRoot());
        StreamReader r = new(cartItemSrc);
        List<DO.CartItem>? lst = (List<DO.CartItem>?)ser.Deserialize(r);
        lst?.Where(f).ToList().ForEach(i => lst.Remove(i));
        r.Close();
         StreamWriter w = new(cartItemSrc);
        ser.Serialize(w, lst);
        w.Close();
    }
}
