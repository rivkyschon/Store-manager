using DalApi;
using DO;
using System.Runtime.CompilerServices;

namespace Dal;

internal class DalProduct : IProduct
{

    /// <summary>
    /// create product
    /// </summary>
    /// <param name="product">the new product</param>
    /// <returns>id of the product</returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(Product p)
    {
        p.ID = DataSource.Config.ProductID;
        DataSource.ProductList.Add(p);
        return p.ID;
    }

    /// <summary>
    ///  Deletes product by given id
    /// </summary>
    /// <param name="id"> Id of product to delete </param>
    /// <exception cref="Exception"> No product found with the given id </exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        if (!DataSource.ProductList.Remove(DataSource.ProductList.Find(p => p.ID == id)))
            throw new ItemNotFound("error can't delete product");
    }


    /// <summary>
    /// Updates an product
    /// </summary>
    /// <param name="updateProduct"> The updated product </param>
    /// <exception cref="Exception"> No order with the given id found </exception>

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(Product p)
    {
        int idx = DataSource.ProductList.FindIndex(pr => pr.ID == p.ID);
        if (idx>=0) DataSource.ProductList[idx] = p;
        else
            throw new ItemNotFound("could not update product");
    }

    /// <summary>
    /// returns all products
    /// </summary>
    /// <returns> all products in system </returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<Product> GetList(Func<Product, bool>? func = null)
    {
        IEnumerable<Product> p = (IEnumerable<Product>)DataSource.ProductList;
        return (func == null ? p : p.Where(func));
    }

    /// <summary>
    /// functiod receives id of product and returns the products details
    /// </summary>
    /// <param name="id">id of specific product</param>
    /// <returns>  product details of given id</returns>
    /// <exception cref="ItemNotFound">no product with requested id found</exception>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public Product Get(Func<Product, bool> func)
    {
        IEnumerable<Product> p = (IEnumerable<Product>)DataSource.ProductList;
        return p.Where(func) != null ? p.Where(func).FirstOrDefault() : throw new ItemNotFound("order Item not found");
    }
}

