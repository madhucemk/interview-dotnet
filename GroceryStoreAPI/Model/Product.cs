using System.Diagnostics.CodeAnalysis;

namespace GroceryStoreAPI.Model
{
    [ExcludeFromCodeCoverage]
    public class Product
    {
        public int id { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}
