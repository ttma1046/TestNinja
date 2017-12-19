using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Add(1, 2);
            
            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var math = new Math();

            var result = math.Max(2, 1);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var math = new Math();

            var result = math.Max(1, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public void Max_BothArgumentsAreEqual_ReturnTheSameArgument()
        {
            var math = new Math();

            var result = math.Max(2, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
    }
}