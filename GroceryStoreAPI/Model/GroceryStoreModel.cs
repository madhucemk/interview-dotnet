using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GroceryStoreAPI.Model
{
    [ExcludeFromCodeCoverage]
    public class GroceryStoreModel
    {
        public IList<Customer> customers { get; set; }
        public IList<Order> orders { get; set; }
        public IList<Product> products { get; set; }
    }
}
