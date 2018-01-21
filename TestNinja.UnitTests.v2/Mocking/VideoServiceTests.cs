using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Repository;

namespace TestNinja.UnitTests.v2.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private Mock<IDeserializer> _jsonDeserializer;
        private Mock<IVideoRepository> _videoRepository;
        private VideoService _videoService;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _jsonDeserializer = new Mock<IDeserializer>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object, _jsonDeserializer.Object); 
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {             
            /*
            var service = new VideoService();

            service.ReadVideoTitle(new FakeFileReader());
            */
            
            // Arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            // Act
            var result = _videoService.ReadVideoTitle();
                                                  
            // Assert
            Assert.That(result, Is.EqualTo("Error parsing the video."));
            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            // Arrange
            var videos = new List<Video>
            {
            };

            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(videos);

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            _videoRepository.Verify(vr => vr.GetUnprocessedVideos());

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnCommonSeperatedVideoIdsinString()
        {
            // Arrange
            var videos = new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 }
            };

            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(videos);
            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            _videoRepository.Verify(vr => vr.GetUnprocessedVideos());
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
