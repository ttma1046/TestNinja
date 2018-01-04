using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;
using TestNinja.Mocking.Repository;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IVideoRepository> videoRepository;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mockFileReader.Object, videoRepository.Object);
        }
        
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            var result = _videoService.ReadVideoTitle();
            
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        
        [Test]
        public void GetUnprocessedVideos_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            // Arrange
            videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();
            // Assert
            Assert.That(result, Is.EqualTo(""));
        }
        
        [Test]
        public void GetUnprocessedVideos_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            // Arrange
            videoRepository.Setup(r => r.GetUnprocessedVideos())
                .Returns(new List<Video> {new Video {Id = 1}, new Video {Id = 2}, new Video {Id = 3}});
            
            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();
            
            // Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}