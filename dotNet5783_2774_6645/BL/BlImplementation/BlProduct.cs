using BlApi;
using BO;
using DalApi;
using DO;
using System.Reflection;

namespace BlImplementation;

public class BlProduct : BlApi.IProduct
{

    private DalApi.IDal dal = DalApi.Factory.Get() ?? throw new BlNullValueException();



    private DO.Product castBOToDO(BO.Product pBO)
    {

        DO.Product pDO = BlUtils.cast<DO.Product, BO.Product>(pBO);
        pDO.Category = (DO.eCategory?)pBO.Category;
        pDO.Amount = (int)pBO.InStock;
        return pDO;
    }

    private S castProduct<S, T>(T t) where S : new()
    {
        S s = BlUtils.cast<S, T>(t);
        var value = t?.GetType().GetProperty("Category")?.GetValue(t, null) ?? throw new BlNullValueException();
        s?.GetType().GetProperty("Category")?.SetValue(s, (BO.eCategory?)(int)value);
        var value2 = t?.GetType().GetProperty("Image")?.GetValue(t, null);
        s?.GetType().GetProperty("Image")?.SetValue(s, (string)value2);
        switch (s?.GetType().Name)
        {
            case "Product":
                var val1 = t?.GetType()?.GetProperty("Amount")?.GetValue(t, null);
                s?.GetType().GetProperty("InStock")?.SetValue(s, val1);
                break;
            case "ProductItem":
                var val2 = t?.GetType()?.GetProperty("Amount")?.GetValue(t, null) ?? throw new BlNullValueException();
                s?.GetType().GetProperty("InStock")?.SetValue(s, ((int)val2 > 0) ? true : false);
                break;
            default:
                break;
        }
        return s;
    }


    /// <summary>
    /// Adds new product
    /// </summary>
    /// <param name="p"> new product </param>
    public int AddProduct(BO.Product p)
    {
        if (p.Price < 0) throw new BlInvalideData();
        if (p.Name == "" || p.Image == null) throw new BlNullValueException();
        if (p.InStock > 0 && p.Category != null)
        {
            int id = dal.Product.Add(castBOToDO(p));
            p.Image = copyFiles(p.Image!, id.ToString());
            return id;

        }
        else throw new BlInvalidAmount();
    }

    /// <summary>
    /// Deletes a product
    /// </summary>
    /// <param name="id"> id of product to delete </param>
    /// <exception cref="BlProductFoundInOrders"> the product exists in users orders </exception>
    /// <exception cref="BlIdNotFound">  no product with id found </exception>
    public void DeleteProduct(int id)
    {
        try
        {
            IEnumerable<DO.OrderItem> orderItems;
            lock (dal)
                orderItems = dal.OrderItem.GetList() ?? throw new BlNullValueException();

            if (orderItems.ToList().Exists(i => i.ProductID == id)) throw new BlProductFoundInOrders();
            dal.Product.Delete(id);
        }
        catch (DalApi.ItemNotFound e) { throw new BlIdNotFound(e); }

    }

    /// <summary>
    /// gets product by id
    /// </summary>
    /// <param name="id"> id of requested product </param>
    /// <returns></returns>
    public BO.Product GetProductForManager(int id)
    {
        return Get(id);
    }

    /// <summary>
    /// gets product by id
    /// </summary>
    /// <param name="id"> id of requested product </param>
    /// <returns></returns>
    public BO.Product GetProductForCustomer(int id)
    {
        return Get(id);
    }

    private BO.Product Get(int id)
    {
        try
        {
            if (id > 0)
            {
                lock (dal)
                    return castProduct<BO.Product, DO.Product>(dal.Product.Get(p => p.ID == id));
            }
            throw new BlInvalideData();
        }
        catch (DalApi.ItemNotFound e) { throw new BlIdNotFound(e); }

    }

    /// <summary>
    /// gets list of products for manager 
    /// </summary>
    /// <returns> list of products </returns>
    public IEnumerable<BO.ProductForList> GetProductList(BO.eCategory? e = null)
    {
        IEnumerable<DO.Product> DOlist;
        if (e != null) DOlist = dal.Product.GetList(p => (int)(object)p.Category == (int)(object)e) ?? throw new BlNullValueException();
        else DOlist = dal.Product.GetList() ?? throw new BlNullValueException();

        IEnumerable<BO.ProductForList> BOlist = from item in DOlist
                                                select castProduct<BO.ProductForList, DO.Product>(item);
        return BOlist;
    }

    /// <summary>
    /// gets list of product for user
    /// </summary>
    /// <returns> list of product, type:productitem</returns>
    public IEnumerable<BO.ProductItem> GetProductItem(BO.eCategory? e = null)
    {
        IEnumerable<DO.Product> DOlist;
        IEnumerable<BO.ProductItem> BOlist;
        lock (dal)
        {
            if (e != null) DOlist = dal.Product.GetList(p => (int)(object)p.Category == (int)(object)e) ?? throw new BlNullValueException();
            else DOlist = dal.Product.GetList() ?? throw new BlNullValueException();
            BOlist = from item in DOlist
                     select castProduct<BO.ProductItem, DO.Product>(item);
        }
        return BOlist;
    }

    /// <summary>
    /// updates product details
    /// </summary>
    /// <param name="p"> product object to update </param>
    /// <exception cref="BlInvalideData"> id is invalid  </exception>
    /// <exception cref="BlNullValueException"> product details missing </exception>
    /// <exception cref="BlIdNotFound"> id of product does not exist </exception>
    public void UpdateProduct(BO.Product p)
    {
        try
        {
            if (p.ID < 0) throw new BlInvalideData();
            if (p.Price < 0 || p.InStock < 0) throw new BlNegativeAmountException();
            if (p.Name == "" || p.Image == null) throw new BlNullValueException();
            if (p.InStock > 0 && p.Category != null)
            {
                p.Image = copyFiles(p.Image!, p.ID.ToString());
                lock (dal)
                    dal.Product.Update(castBOToDO(p));
                return;
            }
            throw new BlInvalidAmount();
        }
        catch (DalApi.ItemNotFound e) { throw new BlIdNotFound(e); }
    }


    private string copyFiles(string sourcePath, string destinationName)
    {
        try
        {
            int postfixIndex = sourcePath.LastIndexOf('.');
            string postfix = sourcePath.Substring(postfixIndex);
            destinationName += postfix;
            string destinationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            destinationPath = destinationPath!.Substring(0, destinationPath.Length - 3);
            string destinationFullName = @"\..\img\" + destinationName;
            System.IO.File.Copy(sourcePath, destinationPath + "\\" + destinationFullName, true);
            string destinationFullNameDal = @"..\\..\\img\" + destinationName;
            return destinationFullNameDal;
        }
        catch (Exception ex)
        {
            return @"..\..\img\0.png";
        }
    }

}


