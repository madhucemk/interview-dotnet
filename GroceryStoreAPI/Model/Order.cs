using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GroceryStoreAPI.Model
{
    [ExcludeFromCodeCoverage]
    public class Order
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; } = DateTime.Now.Date;
        public IList<Item> items { get; set; }
    }
}
