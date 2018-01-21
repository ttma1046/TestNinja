using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.v2.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService _orderService;
        private Mock<IStorage> _storage;

        [SetUp]
        public void Setup()
        {

            _storage = new Mock<IStorage>();
            _orderService = new OrderService(_storage.Object);
        }

        [Test]
        public void PlaceOrder_WhenCalled_ReturnOrderId()
        {
            // Arrange
            var order = new Order();
            _storage.Setup(s => s.Store(order)).Returns(1);

            
            // Act
            var result = _orderService.PlaceOrder(order);

            // Assert
            _storage.Verify(s => s.Store(order));
            Assert.That(result, Is.EqualTo(1));
        }

    }
}
