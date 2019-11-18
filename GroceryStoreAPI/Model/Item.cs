using System.Diagnostics.CodeAnalysis;

namespace GroceryStoreAPI.Model
{
    [ExcludeFromCodeCoverage]
    public class Item
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
