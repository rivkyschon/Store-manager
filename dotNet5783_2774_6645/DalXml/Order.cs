namespace Dal;
using DalApi;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

public class Order : IOrder
{
    static readonly string orderSrc = @"..\..\xml\Order.xml";
    static readonly string configSrc = @"..\..\xml\config.xml";


    private List<DO.Order> createList()
    {
        XElement? root = XDocument.Load(orderSrc).Root;
        IEnumerable<XElement>? rootXelement = root?.Elements("Order") ?? throw new XMLFileNullExeption();
        object orderObj = new DO.Order();
        List<DO.Order> list = new();

        foreach (XElement xmlOrder in rootXelement)
        {
            xmlOrder.Elements().ToList().ForEach(element => initializeXelement(orderObj, element));
            list.Add((DO.Order)orderObj);
        }

        return list;
    }

    private XElement convertToXelement(DO.Order order)
    {
        XElement xmlOrder = new XElement("Order");
        order.GetType().GetProperties().ToList().ForEach(p => xmlOrder.Add(new XElement(p.Name.ToString(), p.GetValue(order, null))));
        return xmlOrder;
    }

    private void initializeXelement(object orderObj, XElement xmlElement)
    {
        PropertyInfo? property = orderObj?.GetType()?.GetProperty(xmlElement.Name.ToString());
        if (xmlElement.Name.ToString() != "ID" && !xmlElement.Name.ToString().EndsWith("Date")&& xmlElement.Name.ToString() != "UserID")
            property?.SetValue(orderObj, xmlElement.Value);
        else if (xmlElement.Name.ToString() == "ID" || xmlElement.Name.ToString() == "UserID")
            property?.SetValue(orderObj, int.Parse(xmlElement.Value));
        else if (xmlElement.Value != "")
            property?.SetValue(orderObj, DateTime.Parse(xmlElement.Value));
        else
            property?.SetValue(orderObj, null);

    }
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(DO.Order order)
    {
        XElement? root = XDocument.Load(orderSrc).Root;
        XElement? rootConfig = XDocument.Load(configSrc).Root;
        XElement? id = rootConfig?.Element("orderID");
        order.ID = Convert.ToInt32(id?.Value) + 1;
        id?.SetValue(order.ID.ToString());
        rootConfig?.Save(configSrc);
        root?.Add(convertToXelement(order));
        root?.Save(orderSrc);
        return order.ID;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        XElement? root = XDocument.Load(orderSrc).Root;
        root?.Elements("Order").Where(o => int.Parse(o.Element("ID")?.Value.ToString() ?? "0") == id).Remove();
        root?.Save(orderSrc);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public DO.Order Get(Func<DO.Order, bool> func)
    {
        List<DO.Order> list = createList();
        return list?.Where(func) != null ? list.Where(func).First() : throw new ItemNotFound("order not found");
    }


    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<DO.Order>? GetList(Func<DO.Order, bool>? func = null)
    {
        List<DO.Order> list = createList();

        return (func == null ? list : list?.Where(func));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(DO.Order order)
    {
        XElement? root = XDocument.Load(orderSrc).Root;
        XElement xmlOrder = convertToXelement(order);
        root?.Elements("Order")?.Where(o => int.Parse(o.Element("ID")?.Value.ToString() ?? "0") == order.ID)?.FirstOrDefault()?.ReplaceWith(xmlOrder);
        root?.Save(orderSrc);
    }
}

