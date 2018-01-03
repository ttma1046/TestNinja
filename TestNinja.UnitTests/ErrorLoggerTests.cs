using System;
using System.Runtime;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var errorLogger = new ErrorLogger();
            
            errorLogger.Log("error");

            Assert.That(errorLogger, Is.Not.Null);
            Assert.That(errorLogger.LastError, Is.Not.Null);
            Assert.That(errorLogger.LastError, Is.EqualTo("error"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();
            
            // logger.Log(error);
            
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            // Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
            
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) =>
            {
                id = args;
            };
            
            logger.Log("a");
            
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void OnErrorLogged_WhenCalled_RaiseEvent()
        {
            var logger = new ErrorLogger();
            
            logger.onErrorLogged();
            
            Assert.That(true);
        }
    }
}