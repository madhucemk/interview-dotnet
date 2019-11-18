using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GroceryStoreAPI.Tests.Controllers
{
    [TestFixture(Category = "UnitTest")]
    public class ProductControllerTests
    {
        private Mock<IProduct> repository;

        [SetUp]
        public new void Setup() => repository = new Mock<IProduct>();

        [Test]
        public async System.Threading.Tasks.Task GetAllProductAsync()
        {
            // Arrange
            var controller = new ProductController(repository.Object);
            var lst = new List<Product>
            {
             new Product
            {
                id = 200,
                description = "Body Cream"
            }
            };
            repository.Setup(repo => repo.GetAllProducts()).Returns(lst);

            // Act
            var response = controller.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task GetProductById()
        {
            // Arrange
            var controller = new ProductController(repository.Object);
            var lst =
             new Product
             {
                 id = 200,
                 description = "Body Cream"
             };
            repository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(lst);

            // Act
            var response = controller.Get(10);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }


        [Test]
        public async System.Threading.Tasks.Task GetProductByDescription()
        {
            // Arrange
            var controller = new ProductController(repository.Object);
            var lst = new List<Product>
            {
             new Product
            {
                id = 200,
                 description = "Body Cream"
            }
            };
            repository.Setup(repo => repo.GetProductsByDescription(It.IsAny<string>())).Returns(lst);

            // Act
            var response = controller.Get("Sachin");

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task SaveProduct()
        {
            // Arrange
            var controller = new ProductController(repository.Object);
            var lst =
             new Product
             {
                 id = 200,
                 description = "Body Cream"
             }
            ;
            repository.Setup(repo => repo.SaveProduct(It.IsAny<Product>())).Returns(lst);

            // Act
            var response = controller.Post(lst);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }
    }
}
