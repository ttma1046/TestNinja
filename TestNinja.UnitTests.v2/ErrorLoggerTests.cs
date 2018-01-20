using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.v2
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger errorLogger;

        [SetUp]
        public void Setup()
        {
            errorLogger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            errorLogger.Log("error log");

            Assert.That(errorLogger.LastError, Is.EqualTo("error log"));
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("")]
        public void Log_InvalidError_ThrowArgumentNullException(string errorMessage)
        {
            Assert.That(() => errorLogger.Log(errorMessage), Throws.ArgumentNullException);
            Assert.That(() => errorLogger.Log(errorMessage), Throws.Exception.TypeOf<ArgumentNullException>());
            
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;

            errorLogger.ErrorLogged += (sender, args) => { id = args; };

            errorLogger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void OnerrorLogged_WhenCalled_RaiseEvent()
        {
            var id = Guid.Empty;
            errorLogger.ErrorLogged += (sender, args) => { id = args; };

            errorLogger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));

            
        }
    }
}
