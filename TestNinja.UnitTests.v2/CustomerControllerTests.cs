using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.v2
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFoundResult()
        {
            

            var result = controller.GetCustomer(0);

            // NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());
            
            // NotFound or one of its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void GetCustomer_IdIsNotZero_ReturnOk(int id)
        {
            

            var result = controller.GetCustomer(id);

            Assert.That(result, Is.TypeOf<Ok>());

            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
