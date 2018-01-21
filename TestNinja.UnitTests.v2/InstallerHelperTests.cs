using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking.File;

namespace TestNinja.UnitTests.v2
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        private string _destinationPath;

        [SetUp]
        public void Setup()
        {
            _destinationPath = "path";
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object, _destinationPath);
        }

        [Test]
        public void DownloadInstaller_WebClientDownloadsTheFile_ReturnTrue()
        {
            // Arrange
            

            // Act
            var result = _installerHelper.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>());
            // Assert

            _fileDownloader.Verify(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            Assert.That(result, Is.True);

        }

        [Test]
        public void DownloadInstaller_WebClientThrowsTheException_ReturnFalse()
        {
            // Arrange
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            // Act
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            // Assert

            _fileDownloader.Verify(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            Assert.That(result, Is.False);
        }
    }
}
