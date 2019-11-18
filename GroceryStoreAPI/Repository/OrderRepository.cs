using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Repository
{
    public class OrderRepository : BaseRepository, IOrder
    {
        public List<Order> GetAllOrders()
        {
            return GetAllData<Order>("orders");
        }
        public Order GetOrderById(int Id)
        {
            return GetAllData<Order>("orders")?.FirstOrDefault(_Order => _Order.id == Id);
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime SearchDate)
        {
            return GetAllData<Order>("orders")?.Where(_Order => DateTime.Compare(SearchDate, _Order.orderDate) == 0);
        }

        public IEnumerable<object> GetOrdersByCustomer(int Id)
        {
            var order = GetAllData<Order>("orders")?.FindAll(_Order => _Order.customerId == Id).ToList();
            var model = GetJObject<GroceryStoreModel>();

            var result = order.SelectMany(
                tbl => tbl.items.Join(model.products, item => item.productId,
                product => product.id,
                (item, product) => new { item.quantity, product.description, product.price, tbl.customerId })).Join(model.customers,
                cust => cust.customerId,
                cust2 => cust2.id,
                (cust, cust2) => new { cust.description, cust.price, cust.quantity, cust2.name });

            return result;
        }
    }
}
