using System.Linq;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        
        // SetUp
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        
        // TearDown
         
        [Test]
        // [Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // Act
            var result = _math.Add(1, 2);
            
            // Assert
            Assert.That(result, Is.EqualTo(3));
            
            // Assert.That(_math, Is.Not.Null);
        }
        
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));
            
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));
            
            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));
            
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
            // not too general not too specfic.
            
        }
         
        /*
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1);
            
            Assert.That(result, Is.EqualTo(2 ));
        }
        
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public void Max_BothArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(2, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }
        */
    }
}