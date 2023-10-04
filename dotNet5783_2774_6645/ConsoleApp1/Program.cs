// See https://aka.ms/new-console-template for more information
using DalApi;
using System.Reflection;

Console.WriteLine("Hello, World!");


var d= Dal.DalXml.Instance;
//d.Order.Add(new DO.Order());
//Assembly.Load("DalXml" ?? throw new DalConfigException($"Package  is null"));
// Console.WriteLine("asdfasdfasd");
DO.Order o = new();
o.CustomerName = "rivky";
o.CustomerAddress = "rivky";
o.CustomerEmail = "rivky";
o.DeliveryDate = DateTime.Now;
o.OrderDate = DateTime.Now;
o.ShipDate = DateTime.Now;


d.Order.Add(o);
