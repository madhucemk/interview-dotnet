using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Repository
{
    public class CustomerRepository : BaseRepository, ICustomer
    {
        public List<Customer> GetAllCustomers()
        {
            return GetAllData<Customer>("customers");
        }
        public Customer GetCustomerById(int Id)
        {
            return GetAllData<Customer>("customers")?.FirstOrDefault(_customer => _customer.id == Id);
        }

        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            return GetAllData<Customer>("customers")?.Where(_customer => string.Equals(_customer.name, name.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public Customer SaveCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer?.name))
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

                if (model.customers == null)
                {
                    var customerList = new List<Customer>();
                    model.customers = customerList;
                }

                var data = model?.customers?.FirstOrDefault(c => c.id == customer.id);
                if (data == null)
                {
                    model?.customers?.Add(customer);
                }
                else
                {
                    data.name = customer.name;
                }

                WriteData(model);
            }

            return customer;
        }
    }
}
