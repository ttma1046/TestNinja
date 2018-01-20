using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.v2
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack<int>();
            
        }

        [Test]        
        public void Push_InputValueIsNull_ThrowArgumentNullException()
        {
            // Arrange
            var stack = new Stack<string>();
            // Act
            
            // Assert
            Assert.That(() => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        [TestCase(3)]
        public void Push_InputValue_ListCountWillIncreaseOne(int input)
        {
            // Arrange

            // Act
            _stack.Push(input);

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(1));
        }    
        
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }
         
        [Test]                                        
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {                             
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_WhenCalled_ReturnTopItemInStack()
        {
            // Arrange
            _stack.Push(10);
            _stack.Push(12);
            _stack.Push(13);
            Assert.That(_stack.Count, Is.EqualTo(3));
            // Act
            var result = _stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo(13));
            Assert.That(_stack.Count, Is.EqualTo(3));
        }


        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }


        [Test]
        public void Pop_WhenCalled_ReturnTopInTheStack()
        {
            // Arrange
            _stack.Push(10);
            _stack.Push(12);
            _stack.Push(13);
            Assert.That(_stack.Count, Is.EqualTo(3));
            // Act
            var result = _stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo(13));
            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}
