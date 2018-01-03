using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;
        
        // SetUp
        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(350)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        
        
        [Test]
        [TestCase(0, 0)]
        [TestCase(50, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(67, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        [TestCase(80, 3)]
        // SpeedIsLessThanOrEqualToSpeedLimit
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}