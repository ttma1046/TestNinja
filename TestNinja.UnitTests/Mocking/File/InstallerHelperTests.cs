using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking.File;

namespace TestNinja.UnitTests.Mocking.File
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> fileDownloader;
        private InstallerHelper installerHelper;
        private string destination;

        [SetUp]
        public void SetUp()
        {
            fileDownloader = new Mock<IFileDownloader>();
            destination = "dest";
            installerHelper = new InstallerHelper(fileDownloader.Object, destination);
        }

        [Test]
        [TestCase("customer", "installer")]
        public void DownloadInstaller_DownloadFileSuccess_CallDownload(string customerName, string installerName)
        {
            // Arrange
            
            
            // Act
            installerHelper.DownloadInstaller(customerName, installerName);

            // Assert
            fileDownloader.Verify(r => r.DownloadFile(
                string.Format("http://example.com/{0}/{1}",
                    customerName,
                    installerName),destination));
        }
        
        [Test]
        [TestCase("customer", "installer")]
        public void DownloadInstaller_DownloadFileSuccess_ReturnTrue(string customerName, string installerName)
        {
            // Arrange

            // Act
            var result = installerHelper.DownloadInstaller(customerName, installerName);

            // Assert
            /*
            fileDownloader.Verify(r => r.DownloadFile(
                string.Format("http://example.com/{0}/{1}",
                    customerName,
                    installerName),
                destination));
            */
            Assert.That(result, Is.EqualTo(true));
        }
        
        [Test]
        [TestCase("customer", "installer")]
        public void DownloadInstaller_DownloadFails_ReturnFalse(string customerName, string installerName)
        {
            // Arrange
            /*
            fileDownloader.Setup(r => r.DownloadFile(string.Format("http://example.com/{0}/{1}",
                customerName,
                installerName), destination)).Throws<WebException>();
            */
            
            fileDownloader.Setup(r => r.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            // Act
            var result = installerHelper.DownloadInstaller(customerName, installerName);
            // Assert
            Assert.That(result, Is.False);
        }
    }
}