using GroceryStoreAPI.Model;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Repository.Interfaces
{
    public interface IOrder
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int Id);
        IEnumerable<Order> GetOrdersByDate(DateTime name);

        IEnumerable<object> GetOrdersByCustomer(int Id);
    }
}
