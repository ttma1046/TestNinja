using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

[NUnit.Framework.TestFixture]
public class DemeritPointsCalculator_CalculateDemeritPointsTests
{
    private DemeritPointsCalculator demeritPointsCalculator;

    [SetUp]
    public void Setup()
    {
        demeritPointsCalculator = new DemeritPointsCalculator();
    }

    [Test]
    [TestCase(-1)]
    [TestCase(301)]
    public void SpeedLessThan0OrOverMaxSpeed_ThrowArgumentOutOfRangeException(int speed)
    {
        // Act


        // Assert
        Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
    }


    [Test]
    [TestCase(0)]
    [TestCase(40)]
    [TestCase(65)]
    public void SpeedLessThanOrEqualToSpeedLimit_ReturnZeroDemeritPoint(int speed)
    {
        // Arrange

        // Act
        var result = demeritPointsCalculator.CalculateDemeritPoints(speed);
        // Assert
        Assert.That(result, Is.EqualTo(0));
    }


    [Test]
    [TestCase(40, 0)]
    [TestCase(65, 0)]
    [TestCase(67 , 0)]
    [TestCase(70, 1)]
    [TestCase(75, 2)]
    [TestCase(80, 3)]
    public void SpeedOverSpeedLimitByEvery5_GetEveryOneDemeritPoint(int speed, int expectedValue)
    {
        // Arrange


        // Act
        var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }
}