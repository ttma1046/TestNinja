using System.Collections.Generic;

namespace TestNinja.Mocking.Repository
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}