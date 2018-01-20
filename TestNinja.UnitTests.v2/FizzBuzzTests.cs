using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.v2
{
    [TestFixture]
    class FizzBuzzTests
    {
        private FizzBuzz fizzBuzz;

        [SetUp]
        public void Setup()
        {
            fizzBuzz = new FizzBuzz();    
       } 
                                             
        [Test]
        public void GetOutPut_InputIsDivisibleBy3Only_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(6);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutPut_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutPut_InputIsDivisibleBy3And5_ReturnBuzzFizz()
        {
            var result = FizzBuzz.GetOutput(30);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutPut_InputIsNotDivisibleBy3Or5_ReturnBuzzFizz()
        {
            var result = FizzBuzz.GetOutput(4);

            Assert.That(result, Is.EqualTo("4"));
        }
    }
}
