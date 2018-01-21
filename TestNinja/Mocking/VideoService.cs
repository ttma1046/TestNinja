using System;
using System.Collections.Generic;
using System.Data.Entity;
using TestNinja.Mocking.Repository;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IDeserializer _deserializer;
        private readonly IVideoRepository _videoRepository;

        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null, IDeserializer deserializer = null)
        {
            this._fileReader = fileReader ?? new FileReader();
            this._deserializer = deserializer ?? new JsonDeserializer();
            this._videoRepository = videoRepository ?? new VideoRepository();
        }
        
        public string ReadVideoTitle() // IFileReader fileReader
        {
            var str = this._fileReader.Read("video.txt"); 
            var video = this._deserializer.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        // [] => ""
        // [{}, {}] => "videoId1, videoId2"
        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = this._videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
            // return "1";
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}