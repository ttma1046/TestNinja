using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<object> _stack;
        
        // SetUp
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<object>();
        }
        
        [Test]
        [TestCase(null)]
        public void Push_NullObjectPassing_ReturnArgumentNullException(object obj)
        {
            Assert.That(() => _stack.Push(obj), Throws.ArgumentNullException);
        }
        
        
    }
}