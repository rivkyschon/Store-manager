using BO;
using System.Runtime.CompilerServices;

namespace BlApi;
public interface IProduct
{
    public IEnumerable<ProductForList?> GetProductList(BO.eCategory? e=null);

    public IEnumerable<ProductItem?> GetProductItem(BO.eCategory? e = null);

    public Product GetProductForCustomer(int id);

    public Product GetProductForManager(int id);

    public int AddProduct(Product p);

    public void DeleteProduct(int id);

    public void UpdateProduct(Product p);

}

