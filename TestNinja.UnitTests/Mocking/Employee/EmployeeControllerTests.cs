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
        public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
        {
            // Arrange
            // Act
            var result = employeeController.DeleteEmployee(1);

            // Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
        
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            // Arrange
            
            // Act
            employeeController.DeleteEmployee(1);
            // Assert
            _employeeStorage.Verify(s => s.DeleteEmployee(1));
        }    
       
    }
}