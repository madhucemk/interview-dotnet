using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GroceryStoreAPI.Tests.Controllers
{
    [TestFixture(Category = "UnitTest")]
    public class CustomerControllerTests
    {
        private Mock<ICustomer> repository;

        [SetUp]
        public new void Setup() => repository = new Mock<ICustomer>();

        [Test]
        public async System.Threading.Tasks.Task GetAllCustomerAsync()
        {
            // Arrange
            var controller = new CustomerController(repository.Object);
            var lst = new List<Customer>
            {
             new Customer
            {
                id = 200,
                name = "Sachin"
            }
            };
            repository.Setup(repo => repo.GetAllCustomers()).Returns(lst);

            // Act
            var response = controller.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task GetCustomerById()
        {
            // Arrange
            var controller = new CustomerController(repository.Object);
            var lst =
             new Customer
             {
                 id = 200,
                 name = "Sachin"
             };
            repository.Setup(repo => repo.GetCustomerById(It.IsAny<int>())).Returns(lst);

            // Act
            var response = controller.Get(10);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }


        [Test]
        public async System.Threading.Tasks.Task GetCustomerByName()
        {
            // Arrange
            var controller = new CustomerController(repository.Object);
            var lst = new List<Customer>
            {
             new Customer
            {
                id = 200,
                name = "Sachin"
            }
            };
            repository.Setup(repo => repo.GetCustomersByName(It.IsAny<string>())).Returns(lst);

            // Act
            var response = controller.Get("Sachin");

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task SaveCustomer()
        {
            // Arrange
            var controller = new CustomerController(repository.Object);
            var lst =
             new Customer
             {
                 id = 200,
                 name = "Sachin"
             }
            ;
            repository.Setup(repo => repo.SaveCustomer(It.IsAny<Customer>())).Returns(lst);

            // Act
            var response = controller.Post(lst);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }
    }
}
