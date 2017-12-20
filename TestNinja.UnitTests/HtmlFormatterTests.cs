using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormateAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            // Arrange
            var formatter = new HtmlFormatter();
            
            // Act
            var result = formatter.FormatAsBold("test");
            
            // Assert
            
            // Specific
            Assert.That(result, Is.EqualTo("<strong>test</strong>").IgnoreCase);
            
            // More general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("test").IgnoreCase);


        }
        
    }
}