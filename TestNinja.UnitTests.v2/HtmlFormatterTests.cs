
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.v2
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        [TestCase("abc")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string content)
        {
            var htmlFormatter = new HtmlFormatter();

            var result = htmlFormatter.FormatAsBold(content);

            // Specific
            // Assert.That(result, Contains.Substring("</strong>"));
            // Assert.That(result, Contains.Substring("<strong>Test</strong>"));
            Assert.That(result, Is.EqualTo($"<strong>{content}</strong>").IgnoreCase);

            // More general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain(content).IgnoreCase);
        }   
    }           
}
