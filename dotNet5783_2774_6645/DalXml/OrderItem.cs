
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Dal;
internal class OrderItem : IOrderItem
{
    static string orderItemSrc = @"..\..\xml\OrderItem.xml";
    public XmlRootAttribute xRoot()
    {
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "ArrayOfOrderItem";
        xRoot.IsNullable = true;
        return xRoot;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(DO.OrderItem orderItem)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.OrderItem>), xRoot());
        StreamReader r = new(orderItemSrc);
        List<DO.OrderItem>? lst = (List<DO.OrderItem>?)ser.Deserialize(r)??throw new XMLFileNullExeption();
        orderItem.ID = lst.Last().ID + 1;
        lst?.Add(orderItem);
        r.Close();
        StreamWriter w = new(orderItemSrc);
        ser.Serialize(w, lst);
        w.Close();
        return orderItem.ID;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.OrderItem>), xRoot());
        StreamReader r = new(orderItemSrc);
        List<DO.OrderItem>? lst = (List<DO.OrderItem>?)ser.Deserialize(r);
        lst?.Remove(lst.Where(o => o.ID == id).FirstOrDefault());
        r.Close();
        StreamWriter w = new(orderItemSrc);
        ser.Serialize(w, lst);
        w.Close();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public DO.OrderItem Get(Func<DO.OrderItem, bool> func)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.OrderItem>), xRoot());
        StreamReader r = new(orderItemSrc);
        List<DO.OrderItem>? lst = (List<DO.OrderItem>?)ser.Deserialize(r);
        r.Close();
        return lst?.Where(func) != null ? lst.Where(func).First() : throw new ItemNotFound("product not found");
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<DO.OrderItem>? GetList(Func<DO.OrderItem, bool>? func = null)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.OrderItem>), xRoot());
        StreamReader r = new(orderItemSrc);
        List<DO.OrderItem>? lst = (List<DO.OrderItem>?)ser.Deserialize(r);
        r.Close();
        return (func == null ? lst : lst?.Where(func));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(DO.OrderItem o)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.OrderItem>), xRoot());
        StreamReader readFile = new(orderItemSrc);
        List<DO.OrderItem>? lst = (List<DO.OrderItem>?)ser.Deserialize(readFile)??throw new XMLFileNullExeption();
        int idx = lst.FindIndex(pr => pr.ID == o.ID);
        if (idx >= 0) lst[idx] = o;
        else
            throw new ItemNotFound("could not update Order Item");
        readFile.Close();
        StreamWriter writeFile = new(orderItemSrc);
        ser.Serialize(writeFile, lst);
        writeFile.Close();
    }
}

