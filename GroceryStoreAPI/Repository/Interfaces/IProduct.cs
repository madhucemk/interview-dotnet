using GroceryStoreAPI.Model;
using System.Collections.Generic;

namespace GroceryStoreAPI.Repository.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product GetProductById(int Id);
        IEnumerable<Product> GetProductsByDescription(string name);
        Product SaveProduct(Product Product);
    }
}
