using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(2);
            
            Assert.That(result, Is.EqualTo("2"));
        }
        
        
        [Test]
        public void GetOutput_InputIsZero_ReturnFizzBuzz()
        {
            // Arrange
            
            
            // Act
            var result = FizzBuzz.GetOutput(0);
            
            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));

        }
        
        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            // Arrange
            
            
            // Act
            var result = FizzBuzz.GetOutput(10);
            
            // Assert
            Assert.That(result, Is.EqualTo("Buzz"));

        }
        
        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            // Arrange
            
            
            // Act
            var result = FizzBuzz.GetOutput(6);
            
            // Assert
            Assert.That(result, Is.EqualTo("Fizz"));

        }
        
        [Test]
        public void GetOutput_InputIsDivisibleBy5and3_ReturnFizzBuzz()
        {
            // Arrange
            
            
            // Act
            var result = FizzBuzz.GetOutput(15);
            
            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));

        }
    }
}