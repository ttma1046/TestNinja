using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<object> _stack;
        
        //  
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<object>();
        }
        
        [Test]
        [TestCase(null)]
        public void Push_NullObjectPassing_ThrowArgumentNullException(object obj)
        {
            Assert.That(() => _stack.Push(obj), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(10)]
        public void Push_WhenCalled_AddItemIntotheList(int item)
        {
            var perviousCount = _stack.Count;
            _stack.Push(item);
            var currentCount = _stack.Count;
            
            Assert.That(currentCount - perviousCount, Is.EqualTo(1));
        }
        
        [Test]
        [TestCase(10)]
        public void Push_WhenCalled_AddItemIntotheListCanPeek(int item)
        {
            var perviousCount = _stack.Count;
            _stack.Push(item);
            var currentCount = _stack.Count;
            var result = _stack.Peek();
            
            Assert.That(currentCount - perviousCount, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(item));
        }
        
        [Test]
        public void Pop_NothingInTheStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        
        [Test]
        [TestCase(10)]
        public void Pop_WhenCalled_ReturnLastItem(int item)
        {
            _stack.Push(item);
            var result = _stack.Pop();
            
            Assert.That(result, Is.EqualTo(item));
        }
        
        [Test]
        [TestCase(10)]
        public void Pop_WhenCalled_ItemRemoveFromtheList(int item)
        {
            _stack.Push(item);
            var perviousCount = _stack.Count;
            var result = _stack.Pop();
            var currentCount = _stack.Count;
            Assert.That(result, Is.EqualTo(item));
            Assert.That(perviousCount - currentCount, Is.EqualTo(1));
        }
        
        [Test]
        public void Peek_NothingInTheStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        
        [Test]
        [TestCase(10)]
        public void Peek_WhenCalled_LastItemInTheListReturn(int item)
        {
            _stack.Push(item);
            var result = _stack.Peek();
            
            Assert.That(result, Is.EqualTo(item));
        }
    }
}