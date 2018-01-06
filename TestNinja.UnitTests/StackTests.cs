using System;
using System.Collections;
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
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();
             
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Stack<string>();
            
            stack.Push("a");
            
            Assert.That(stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            
            Assert.That(stack.Count, Is.EqualTo(0));
        }
                
        [Test]
        public void Pop_NothingInTheStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
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
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            var result = stack.Pop();
            
            // Assert
            Assert.That(result, Is.EqualTo("c"));
        }
        
        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            stack.Pop();
            
            // Assert
            Assert.That(stack.Count, Is.EqualTo(2));
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
        
        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<string>();
            // Act

            // Assert
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            var result = stack.Peek();
            
            // Assert
            Assert.That(result, Is.EqualTo("c"));
        }
        
        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            stack.Peek();
            
            // Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}