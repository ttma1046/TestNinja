using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking.Employee;

namespace TestNinja.UnitTests.v2.Mocking.Employee
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_EmployeeDelelted()
        {
            // Act
            _employeeController.DeleteEmployee(1);

            // Assert
            _employeeStorage.Verify(es => es.DeleteEmployee(1));            
        }


        [Test]
        public void DeleteEmployee_WhenCalled_RedirectToActionEmployees()
        {
            // Arrange

            // Act
            var result = _employeeController.DeleteEmployee(1);
            // Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }


}
