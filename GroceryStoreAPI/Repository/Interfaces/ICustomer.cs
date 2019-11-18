using GroceryStoreAPI.Model;
using System.Collections.Generic;

namespace GroceryStoreAPI.Repository.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int Id);
        IEnumerable<Customer> GetCustomersByName(string name);
        Customer SaveCustomer(Customer customer);
    }
}
