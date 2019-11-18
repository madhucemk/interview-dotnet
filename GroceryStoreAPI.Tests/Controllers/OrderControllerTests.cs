using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Tests.Controllers
{
    [TestFixture(Category = "UnitTest")]
    public class OrderControllerTests
    {
        private Mock<IOrder> repository;

        [SetUp]
        public new void Setup() => repository = new Mock<IOrder>();

        [Test]
        public async System.Threading.Tasks.Task GetAllOrderAsync()
        {
            // Arrange
            var controller = new OrderController(repository.Object);
            var lst = new List<Order>
            {
             new Order
            {
                id = 200,
                customerId=1
            }
            };
            repository.Setup(repo => repo.GetAllOrders()).Returns(lst);

            // Act
            var response = controller.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task GetOrderById()
        {
            // Arrange
            var controller = new OrderController(repository.Object);
            var lst =
             new Order
             {
                 id = 200,
                 customerId = 1
             };
            repository.Setup(repo => repo.GetOrderById(It.IsAny<int>())).Returns(lst);

            // Act
            var response = controller.Get(10);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }


        [Test]
        public async System.Threading.Tasks.Task GetOrderByDate()
        {
            // Arrange
            var controller = new OrderController(repository.Object);
            var lst = new List<Order>
            {
             new Order
            {
                id = 200,
                customerId = 1
            }
            };
            repository.Setup(repo => repo.GetOrdersByDate(It.IsAny<DateTime>())).Returns(lst);

            // Act
            var response = controller.Get(DateTime.Now);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }
    }
}
