
namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

internal class Product : IProduct
{
    string productSrc = @"..\..\xml\Product.xml";
    [MethodImpl(MethodImplOptions.Synchronized)]
    public XmlRootAttribute xRoot()
    {
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "ArrayOfProduct";
        xRoot.IsNullable = true;
        return xRoot;
    }
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(DO.Product product)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.Product>), xRoot());
        StreamReader r = new(productSrc);
        List<DO.Product>? lst = (List<DO.Product>?)ser.Deserialize(r);
        product.ID = lst?.Last().ID + 1 ?? throw new XMLFileNullExeption();
        lst?.Add(product);
        r.Close();
        StreamWriter w = new(productSrc);
        ser.Serialize(w, lst);
        w.Close();
        return product.ID;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.Product>), xRoot());
        StreamReader r = new(productSrc);
        List<DO.Product>? lst = (List<DO.Product>?)ser.Deserialize(r);
        lst?.Remove(lst.Where(p => p.ID == id).FirstOrDefault());
        r.Close();
        StreamWriter w = new(productSrc);
        ser.Serialize(w, lst);
        w.Close();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public DO.Product Get(Func<DO.Product, bool> func)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.Product>), xRoot());
        StreamReader r = new(productSrc);
        List<DO.Product>? lst = (List<DO.Product>?)ser.Deserialize(r);
        r.Close();
        return lst?.Where(func) != null ? lst.Where(func).First() : throw new ItemNotFound("product not found");
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<DO.Product>? GetList(Func<DO.Product, bool>? func = null)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.Product>), xRoot());
        StreamReader r = new(productSrc);
        List<DO.Product>? lst = (List<DO.Product>?)ser.Deserialize(r);
        r.Close();
        return (func == null ? lst : lst?.Where(func));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(DO.Product p)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<DO.Product>), xRoot());
        StreamReader readFile = new(productSrc);
        List<DO.Product>? lst = (List<DO.Product>?)ser.Deserialize(readFile) ?? throw new XMLFileNullExeption();
        int idx = lst.FindIndex(pr => pr.ID == p.ID);
        if (idx >= 0) lst[idx] = p;
        else
            throw new ItemNotFound("could not update product");
        readFile.Close();
        StreamWriter writeFile = new(productSrc);
        ser.Serialize(writeFile, lst);
        writeFile.Close();
    }
}

