using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Repository
{
    public class ProductRepository : BaseRepository, IProduct
    {
        public List<Product> GetAllProducts()
        {
            return GetAllData<Product>("products");
        }
        public Product GetProductById(int Id)
        {
            return GetAllData<Product>("products")?.FirstOrDefault(_product => _product.id == Id);
        }

        public IEnumerable<Product> GetProductsByDescription(string description)
        {
            return GetAllData<Product>("Products")?.Where(_Product => string.Equals(_Product.description, description.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public Product SaveProduct(Product Product)
        {
            if (string.IsNullOrEmpty(Product?.description))
            {
                throw new Exception("Invalid Input");
            }
            else
            {
                var model = GetJObject<GroceryStoreModel>();
                if (model == null)
                {
                    model = new GroceryStoreModel();
                }

                if (model.products == null)
                {
                    var ProductList = new List<Product>();
                    model.products = ProductList;
                }

                var data = model?.products?.FirstOrDefault(c => c.id == Product.id);
                if (data == null)
                {
                    model?.products?.Add(Product);
                }
                else
                {
                    data.description = Product.description;
                    data.price = Product.price;
                }

                WriteData(model);
            }

            return Product;
        }
    }
}
