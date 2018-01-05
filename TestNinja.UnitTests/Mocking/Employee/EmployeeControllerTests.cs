using Moq;
using NUnit.Framework;
using TestNinja.Mocking.Employee;

namespace TestNinja.UnitTests.Mocking.Employee
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController employeeController;
            
        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            
            employeeController = new EmployeeController(_employeeStorage.Object);
        }
        
        [Test]
        public void DeleteEmployee__()
        {
            // Arrange
            // Act
            var result = employeeController.DeleteEmployee(0);

            // Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}